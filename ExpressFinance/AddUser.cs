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
    public partial class AddUser : Form
    {
        private int userId;
        private string sqlConnect;
        public AddUser(int userId, string sqlConnect)
        {
            InitializeComponent();
            this.userId = userId; // Зберегти ID користувача
            this.sqlConnect = sqlConnect;
        }

        private void tpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка, что вводятся только цифры и управляющие символы (например, backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отклоняем ввод
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string email = tlogin.Text.Trim();
            string password = tpassword.Text.Trim();
            string card = tcard.Text.Trim();
            decimal initialBalance = 0;
            string selectedRole = comboBox_Role.SelectedItem?.ToString(); // Получение выбранной роли из comboBox_Role
            string selectedFop = comboBox_Fop.SelectedItem?.ToString(); // Получение выбранного FOP из comboBox_Fop

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(card) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    // Проверка уникальности пароля
                    string sqlCheckPassword = "SELECT COUNT(*) FROM users WHERE password = @Password";
                    using (NpgsqlCommand checkPasswordCommand = new NpgsqlCommand(sqlCheckPassword, connection))
                    {
                        checkPasswordCommand.Parameters.AddWithValue("@Password", password);
                        long passwordCount = Convert.ToInt64(checkPasswordCommand.ExecuteScalar());

                        if (passwordCount > 0)
                        {
                            MessageBox.Show("Пароль вже існує. Будь ласка, виберіть інший пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Проверка уникальности номера карты
                    string sqlCheckCard = "SELECT COUNT(*) FROM users WHERE card_number = @Card";
                    using (NpgsqlCommand checkCardCommand = new NpgsqlCommand(sqlCheckCard, connection))
                    {
                        checkCardCommand.Parameters.AddWithValue("@Card", card);
                        long cardCount = Convert.ToInt64(checkCardCommand.ExecuteScalar());

                        if (cardCount > 0)
                        {
                            MessageBox.Show("Номер карти вже існує. Будь ласка, введіть інший номер карти.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Вставка нового пользователя в таблицу users
                        string sqlInsertUser = @"
                INSERT INTO users (email, password, card_number, user_role, fop)
                VALUES (@Email, @Password, @Card, @UserRole, @Fop)
                RETURNING user_id;
                ";

                        using (NpgsqlCommand command = new NpgsqlCommand(sqlInsertUser, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@Card", card);
                            command.Parameters.AddWithValue("@UserRole", selectedRole);
                            command.Parameters.AddWithValue("@Fop", selectedFop != null ? (object)selectedFop : DBNull.Value); // передаем DBNull.Value, если ничего не выбрано

                            // Получаем user_id только что добавленного пользователя
                            long newUserId = Convert.ToInt64(command.ExecuteScalar());

                            // Вставка начального баланса в таблицу balances
                            string sqlInsertBalance = @"
                    INSERT INTO balances (user_id, balance)
                    VALUES (@UserId, @InitialBalance);
                    ";

                            using (NpgsqlCommand insertBalanceCommand = new NpgsqlCommand(sqlInsertBalance, connection, transaction))
                            {
                                insertBalanceCommand.Parameters.AddWithValue("@UserId", newUserId);
                                insertBalanceCommand.Parameters.AddWithValue("@InitialBalance", initialBalance);
                                insertBalanceCommand.ExecuteNonQuery();
                            }

                            // Вставка начального кэшбэка в таблицу cashback
                            string sqlInsertCashback = @"
                    INSERT INTO cashback (user_id, total_cashback)
                    VALUES (@UserId, 0);
                    ";

                            using (NpgsqlCommand insertCashbackCommand = new NpgsqlCommand(sqlInsertCashback, connection, transaction))
                            {
                                insertCashbackCommand.Parameters.AddWithValue("@UserId", newUserId);
                                insertCashbackCommand.ExecuteNonQuery();
                            }

                            // Нетранзакционная вставка записи транзакции в таблицу transactions
                            string sqlInsertTransaction = @"
                    INSERT INTO transactions (user_id, receiver_id, amount, transaction_date)
                    VALUES (@UserId, @UserId, @InitialBalance, NOW());
                    ";

                            using (NpgsqlCommand insertTransactionCommand = new NpgsqlCommand(sqlInsertTransaction, connection, transaction))
                            {
                                insertTransactionCommand.Parameters.AddWithValue("@UserId", newUserId);
                                insertTransactionCommand.Parameters.AddWithValue("@InitialBalance", initialBalance);
                                insertTransactionCommand.ExecuteNonQuery();
                            }

                            // Добавление записи в таблицу history
                            string sqlInsertHistory = @"
                    INSERT INTO history (user_id, email, card_number, action)
                    VALUES (@UserId, @Email, @Card, 'User Added');
                    ";

                            using (NpgsqlCommand insertHistoryCommand = new NpgsqlCommand(sqlInsertHistory, connection, transaction))
                            {
                                insertHistoryCommand.Parameters.AddWithValue("@UserId", newUserId);
                                insertHistoryCommand.Parameters.AddWithValue("@Email", email);
                                insertHistoryCommand.Parameters.AddWithValue("@Card", card);
                                insertHistoryCommand.ExecuteNonQuery();
                            }

                            // Фиксация транзакции
                            transaction.Commit();
                        }
                    }

                    MessageBox.Show("Новий користувач успішно доданий.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час додавання нового користувача: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkfop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkfop.Checked)
            {
                comboBox_Fop.Visible = true;
                label5.Visible = true;
            }
            else
            {
                comboBox_Fop.Visible = false;
                label5.Visible = false;
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // Устанавливаем максимальную длину текста для текстового поля
            tpassword.MaxLength = 4;
            tcard.MaxLength = 16;
            // Подписываемся на событие KeyPress для фильтрации вводимых символов
            tpassword.KeyPress += tpassword_KeyPress;
            tcard.KeyPress += tpassword_KeyPress;
            // Подключение обработчика события KeyPress
            this.tlogin.KeyPress += new KeyPressEventHandler(this.tlogin_KeyPress);
        }
        private void tlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешенные символы: украинские буквы и пробел
            string allowedChars = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";

            // Проверка введенного символа
            if (!allowedChars.Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Отклонить символ
            }
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей
            tlogin.Text = string.Empty;
            tpassword.Text = string.Empty;
            tcard.Text = string.Empty;

            // Очистка комбинированных списков
            comboBox_Role.SelectedIndex = -1;
            comboBox_Fop.SelectedIndex = -1;
        }

    }
}
