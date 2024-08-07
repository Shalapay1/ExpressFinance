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

namespace ExpressFinance
{
    public partial class Cashback : Form
    {
        private string sqlConnect;
        private int userId;
        // Переменная для хранения выбора пользователя
        private string selectedOption = "";
        decimal TotalCashback = 0;
        public Cashback(string sqlConnect, int userId)
        {
            InitializeComponent();
            this.sqlConnect = sqlConnect;
            this.userId = userId;
            // Привязка обработчиков событий CheckedChanged к радиокнопкам
            radioButtonFood.CheckedChanged += radioButtonFood_CheckedChanged;
            radioButtonCar.CheckedChanged += radioButtonCar_CheckedChanged;
            radioButtonClothing.CheckedChanged += radioButtonClothing_CheckedChanged;
        }


        private void Cashback_Load(object sender, EventArgs e)
        {
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

                                // Установка состояния чекбоксов в соответствии с данными из БД
                                radioButtonCar.Checked = carSelected;
                                radioButtonFood.Checked = foodSelected;
                                radioButtonClothing.Checked = clothingSelected;
                            }
                            else
                            {
                                // Если данные о кешбеке для данного пользователя не найдены, выведите сообщение об ошибке или просто оставьте чекбоксы в исходном состоянии
                                MessageBox.Show("Дані про кешбек для цього користувача не знайдено.");
                            }
                        }
                    }
                }

                // Запрос для выборки кешбека для текущего пользователя по его user_id
                string sqlQuery = "SELECT total_cashback FROM cashback WHERE user_id = @UserId";

                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                    {
                        // Передача user_id в параметры запроса
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Чтение значений кешбека из результатов запроса
                                TotalCashback = Convert.ToDecimal(reader["total_cashback"]);

                                // Дальнейшая обработка значений кешбека, например, вывод на форму
                                // Например:
                                ltotal_cash.Text = $"Ваш баланс кешбеку: {TotalCashback:c}";
                            }
                            else
                            {
                                MessageBox.Show("Кешбек для цього користувача не знайдено.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних про кешбек: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Метод для передачи выбранного значения другому классу
        public string GetSelectedOption()
        {
            return selectedOption;
        }

        private void bcashback_out_Click(object sender, EventArgs e)
        {
            // Проверка, что пользователь выбран
            if (userId == 0)
            {
                MessageBox.Show("Користувач не обраний.");
                return;
            }

            // Проверка, что сумма пополнения указана
            if (string.IsNullOrEmpty(ltotal_cash.Text))
            {
                MessageBox.Show("Введіть суму для поповнення балансу.");
                return;
            }



            // SQL-запрос для обновления баланса пользователя в таблице balance
            string sqlUpdateBalance = @"
                    UPDATE balances 
                    SET balance = balance + @CashbackOutAmount
                    WHERE user_id = @UserId;
                ";

            // SQL-запрос для обнуления total_cashback в таблице cashback
            string sqlResetCashback = @"
                    UPDATE cashback 
                    SET total_cashback = 0
                    WHERE user_id = @UserId;
                ";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Обновление баланса пользователя
                        using (NpgsqlCommand updateBalanceCommand = new NpgsqlCommand(sqlUpdateBalance, connection, transaction))
                        {
                            updateBalanceCommand.Parameters.AddWithValue("@CashbackOutAmount", TotalCashback);
                            updateBalanceCommand.Parameters.AddWithValue("@UserId", userId);
                            updateBalanceCommand.ExecuteNonQuery();
                        }

                        // Обнуление total_cashback в таблице cashback
                        using (NpgsqlCommand resetCashbackCommand = new NpgsqlCommand(sqlResetCashback, connection, transaction))
                        {
                            resetCashbackCommand.Parameters.AddWithValue("@UserId", userId);
                            resetCashbackCommand.ExecuteNonQuery();
                        }

                        // Фиксация транзакции
                        transaction.Commit();


                        // Успешное завершение операции
                        MessageBox.Show("Баланс користувача успішно поповнено, і кешбек обнулено.");
                    }
                    catch (Exception ex)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        MessageBox.Show($"Помилка під час поповнення балансу й обнулення кешбеку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string selectedOption = GetSelectedOption();

            if (string.IsNullOrEmpty(selectedOption))
            {
                MessageBox.Show("Выберите опцию кешбека.");
                return;
            }

            UpdateCashback(selectedOption);
            // Открыть панель пользователя
            UserPanel userPanel = new UserPanel(userId, sqlConnect);
            this.Hide();
            userPanel.ShowDialog();
            this.Close();
        }


        private void UpdateCashback(string selectedOption)
        {
            string sqlUpdateCashback = "";
            Console.WriteLine(selectedOption);

            // Определить, какой чекбокс был выбран и выполнить соответствующий SQL-запрос
            switch (selectedOption)
            {
                case "car":
                    sqlUpdateCashback = "UPDATE cashback SET car_selected = TRUE WHERE user_id = @UserId";
                    break;
                case "food":
                    sqlUpdateCashback = "UPDATE cashback SET food_selected = TRUE WHERE user_id = @UserId";
                    break;
                case "clothing":
                    sqlUpdateCashback = "UPDATE cashback SET clothing_selected = TRUE WHERE user_id = @UserId";
                    break;
                default:
                    // Обработка ошибки, если ни один чекбокс не выбран
                    MessageBox.Show($"Выберите опцию кешбека.{selectedOption}");
                    return;
            }

            // Выполнить SQL-запрос
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(sqlUpdateCashback, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void radioButtonFood_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFood.Checked)
            {
                // Выбран чекбокс "Еда"
                selectedOption = "food";
                UpdateCashback(selectedOption); // Вызов метода для обновления кешбека
            }
        }

        private void radioButtonCar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCar.Checked)
            {
                // Выбран чекбокс "Автомобиль"
                selectedOption = "car";
                UpdateCashback(selectedOption); // Вызов метода для обновления кешбека
            }
        }

        private void radioButtonClothing_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClothing.Checked)
            {
                // Выбран чекбокс "Одежда"
                selectedOption = "clothing";
                UpdateCashback(selectedOption); // Вызов метода для обновления кешбека
            }
        }

        
    }
}
