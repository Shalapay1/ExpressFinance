using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ExpressFinance
{
    public partial class TransferForm : Form
    {
        public decimal userBalance;
        internal decimal Amount;
        internal string RecipientCardNumber;
        private string sqlConnect;
        private int userId;

        public TransferForm(decimal userBalance, string sqlConnect, int userId)
        {
            InitializeComponent();
            this.userBalance = userBalance;
            this.sqlConnect = sqlConnect;
            this.userId = userId;
        }

        public void TransferForm_Load(object sender, EventArgs e)
        {
            string balance = Convert.ToString(userBalance);
            lblBalance.Text = $"На вашому рахунку: {balance:C}"; 

        }

        private int GetUserIdByCardNumber(string recipientCardNumber)
        {
            string sqlUserInfo = "SELECT user_id FROM users WHERE card_number = @RecipientCardNumber";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(sqlUserInfo, connection))
                {
                    command.Parameters.AddWithValue("@RecipientCardNumber", recipientCardNumber);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Если есть записи, удовлетворяющие условию, возвращаем ID пользователя
                            return Convert.ToInt32(reader["user_id"]);
                        }
                        else
                        {
                            // Если нет записей, удовлетворяющих условию, возвращаем -1
                            return -1;
                        }
                    }
                }
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string summa = textBox2.Text;
            decimal amount = Convert.ToDecimal(summa);
            string recipientCardNumber = textBox1.Text;

            // Проверяем, существует ли карта получателя
            int recipientUserId = GetUserIdByCardNumber(recipientCardNumber);
            if (recipientUserId != -1)
            {
                // Карта получателя существует, теперь вы можете использовать recipientUserId
                // для выполнения дальнейших операций, например, добавления транзакции
                AddTransaction(recipientUserId, amount);

            }
            else
            {
                // Если карта получателя не существует, выводим сообщение об ошибке
                MessageBox.Show("Картку одержувача не знайдено.");
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Відкрийте панель користувача
            UserPanel userPanel = new UserPanel(userId, sqlConnect); // передайте userId у конструктор UserPanel
            this.Hide();
            userPanel.ShowDialog();
            this.Close();
        }

        private void AddTransaction(int recipientUserId, decimal amount)
        {
            try
            {
                // SQL-запрос для обновления баланса пользователя
                string sqlUpdateBalance = "UPDATE balances SET balance = balance + @Amount WHERE user_id = @UserId";

                // SQL-запрос для добавления новой транзакции
                string sqlAddTransaction = "INSERT INTO transactions (user_id, amount, transaction_date, receiver_id ) VALUES (@UserId, @Amount, @TransactionDate, @Reciver_id)";

                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();
                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Найдите баланс отправителя
                            decimal balance;
                            string sqlSelectSenderBalance = "SELECT balance FROM balances WHERE user_id = @UserId";
                            using (NpgsqlCommand selectSenderBalanceCommand = new NpgsqlCommand(sqlSelectSenderBalance, connection, transaction))
                            {
                                selectSenderBalanceCommand.Parameters.AddWithValue("@UserId", userId);
                                balance = Convert.ToDecimal(selectSenderBalanceCommand.ExecuteScalar());
                            }

                            // Проверьте, достаточно ли средств у отправителя
                            if (balance < amount)
                            {
                                MessageBox.Show("Недостатньо коштів для здійснення транзакції.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            // Обновление баланса пользователя
                            using (NpgsqlCommand updateCommand = new NpgsqlCommand(sqlUpdateBalance, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@Amount", amount);
                                updateCommand.Parameters.AddWithValue("@UserId", recipientUserId);

                                updateCommand.ExecuteNonQuery();
                            }

                            // Добавление новой транзакции
                            using (NpgsqlCommand addTransactionCommand = new NpgsqlCommand(sqlAddTransaction, connection, transaction))
                            {
                                addTransactionCommand.Parameters.AddWithValue("@UserId", recipientUserId);
                                addTransactionCommand.Parameters.AddWithValue("@Amount", amount);
                                addTransactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                                addTransactionCommand.Parameters.AddWithValue("@Reciver_id", userId);

                                addTransactionCommand.ExecuteNonQuery();
                            }
                            // Добавьте новую транзакцию для отправителя
                            string sqlAddSenderTransaction = "INSERT INTO transactions (user_id, amount, transaction_date, receiver_id) VALUES (@UserId, @Amount, @TransactionDate, @ReceiverId)";
                            using (NpgsqlCommand addSenderTransactionCommand = new NpgsqlCommand(sqlAddSenderTransaction, connection, transaction))
                            {
                                addSenderTransactionCommand.Parameters.AddWithValue("@UserId", userId);
                                addSenderTransactionCommand.Parameters.AddWithValue("@Amount", -amount); // Отрицательная сумма для отправителя
                                addSenderTransactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                                addSenderTransactionCommand.Parameters.AddWithValue("@ReceiverId", recipientUserId);
                                addSenderTransactionCommand.ExecuteNonQuery();
                            }
                            // Обновите баланс отправителя
                            decimal updatedSenderBalance = balance - amount;
                            string sqlUpdateSenderBalance = "UPDATE balances SET balance = @UpdatedBalance WHERE user_id = @UserId";
                            using (NpgsqlCommand updateSenderBalanceCommand = new NpgsqlCommand(sqlUpdateSenderBalance, connection, transaction))
                            {
                                updateSenderBalanceCommand.Parameters.AddWithValue("@UpdatedBalance", updatedSenderBalance);
                                updateSenderBalanceCommand.Parameters.AddWithValue("@UserId", userId);
                                updateSenderBalanceCommand.ExecuteNonQuery();
                            }

                            // Добавление кэшбэка в запись отправителя
                                Cashback(recipientUserId, amount);

                            // Фиксация транзакции
                            transaction.Commit();

                            // Успешное завершение операции
                            MessageBox.Show("Транзакцію успішно додано і баланс користувача оновлено.");
                        }
                        catch (Exception ex)
                        {
                            // Откат транзакции в случае ошибки
                            transaction.Rollback();
                            MessageBox.Show($"Помилка під час додавання транзакції: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Відкрийте панель користувача
                    UserPanel userPanel = new UserPanel(userId, sqlConnect); 
                    this.Hide();
                    userPanel.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обращении к базе данных: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Cashback (int recipientUserId, decimal amount)
        {
            string sqlCheckFOP = @"
                SELECT 
                    fop 
                FROM 
                    users 
                WHERE 
                    user_id = @RecipientId;
                ";
            // Добавление кэшбэка в запись отправителя
                string sqlAddCashback = @"
                    INSERT INTO cashback (user_id, total_cashback)
                    VALUES (@RecipientId, @CashbackAmount)
                    ON CONFLICT (user_id) DO UPDATE 
                    SET total_cashback = cashback.total_cashback + EXCLUDED.total_cashback;
                ";

            decimal cashbackAmount = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Проверяем значения в столбцах fop, car, food и clothing для получателя
                        using (NpgsqlCommand checkFOPCommand = new NpgsqlCommand(sqlCheckFOP, connection, transaction))
                        {
                            checkFOPCommand.Parameters.AddWithValue("@RecipientId", recipientUserId);

                            using (NpgsqlDataReader reader = checkFOPCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Проверяем наличие хотя бы одного из значений
                                    if (!reader.IsDBNull(0) || !reader.IsDBNull(1) || !reader.IsDBNull(2) || !reader.IsDBNull(3))
                                    {
                                        // Проверяем наличие хотя бы одного из значений
                                        if (!reader.IsDBNull(0))
                                        {
                                            // Выполняем запрос GetCashbackCommand после освобождения соединения
                                            List<string> selectedOption = GetCashbackCommand();

                                            // Теперь у вас есть информация о выбранном чекбоксе
                                            // Вы можете использовать ее для определения размера кешбека и дальнейших действий
                                            cashbackAmount = GetCashbackAmount(selectedOption, amount); // Функция для определения размера кешбека в зависимости от выбранного чекбокса

                                           
                                        }
                                       

                                    }
                                    else
                                    {
                                        // Если не найдено ни одного значения, выводим сообщение об ошибке или просто не выполняем операцию кэшбэка
                                        MessageBox.Show("У одержувача відсутнє право на кешбек.");
                                    }
                                }
                                else
                                {
                                    // Если не найдена запись о пользователе, выводим сообщение об ошибке
                                    MessageBox.Show("Одержувач не знайдений");
                                }
                               
                                
                            }
                        }
                        // Добавление кешбека в запись получателя
                        using (NpgsqlCommand addCashbackCommand = new NpgsqlCommand(sqlAddCashback, connection, transaction))
                        {
                            addCashbackCommand.Parameters.AddWithValue("@RecipientId", userId);
                            addCashbackCommand.Parameters.AddWithValue("@CashbackAmount", cashbackAmount);

                            addCashbackCommand.ExecuteNonQuery();
                        }

                        // Фиксация транзакции
                        transaction.Commit();

                        // Успешное завершение операции
                        MessageBox.Show("Транзакцію успішно додано, баланс користувача оновлено, і кешбек зараховано.");
                    }
                    catch (Exception ex)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        MessageBox.Show($"Помилка під час додавання кешбеку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private decimal GetCashbackAmount(List<string> selectedOptions, decimal amount)
        {
            // Создаем словарь для хранения процентов кэшбэка для каждой опции
            Dictionary<string, decimal> cashbackPercentages = new Dictionary<string, decimal>
            {
                { "food", 0.05m },
                { "car", 0.02m },
                { "clothing", 0.04m }
            };

            // Инициализируем общий процент кэшбэка
            decimal totalCashbackPercent = 0.0m;

            // Считаем общий процент кэшбэка на основе выбранных опций
            foreach (string option in selectedOptions)
            {
                if (cashbackPercentages.ContainsKey(option))
                {
                    totalCashbackPercent += cashbackPercentages[option];
                }
            }

            // Вычисляем сумму кэшбэка на основе общего процента
            decimal cashbackAmount = amount * totalCashbackPercent;

            return cashbackAmount;
        }
        private List<string> GetCashbackCommand()
        {
            List<string> selectCash = new List<string>();
            try
            {
                // SQL-запрос для получения выбранных чекбоксов для текущего пользователя
                string sqlCheck = @"
                SELECT car_selected, food_selected, clothing_selected 
                FROM cashback 
                WHERE user_id = @UserId
            ";

                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlCheck, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Чтение значений чекбоксов из результатов запроса
                                bool carSelected = reader.GetBoolean(0);
                                bool foodSelected = reader.GetBoolean(1);
                                bool clothingSelected = reader.GetBoolean(2);

                                // Добавление значений с true в список selectCash
                                if (carSelected)
                                    selectCash.Add("car");
                                if (foodSelected)
                                    selectCash.Add("food");
                                if (clothingSelected)
                                    selectCash.Add("clothing");
                            }
                            else
                            {
                                // Если данные о кешбеке для данного пользователя не найдены, выведите сообщение об ошибке или просто оставьте чекбоксы в исходном состоянии
                                MessageBox.Show("Дані про кешбек для цього користувача не знайдено.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних про кешбек: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return selectCash;
        }



    }
}
