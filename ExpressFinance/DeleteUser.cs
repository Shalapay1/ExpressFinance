using Npgsql;
using System;
using System.Windows.Forms;

namespace ExpressFinance
{
    public partial class DeleteUser : Form
    {
        private int userId;
        private string sqlConnect;
        public DeleteUser(int userId, string sqlConnect)
        {
            InitializeComponent();
            this.userId = userId; // Зберегти ID користувача
            this.sqlConnect = sqlConnect;
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchKey = tDeletEmail.Text.Trim(); // Получить значение для поиска (email или card_number)

            // Проверить, что значение для поиска не пустое
            if (string.IsNullOrEmpty(searchKey))
            {
                MessageBox.Show("Введіть email або номер картки для видалення користувача.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var userInfo = FindUserBySearchKey(searchKey); // Найти информацию о пользователе по email или card_number

                if (userInfo == default) // Проверка на отсутствие пользователя
                {
                    MessageBox.Show("Користувач із зазначеним email або номером картки не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Удалить пользователя из всех связанных таблиц
                DelUser(userInfo);

                MessageBox.Show("Користувача успішно видалено з бази даних.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час видалення користувача: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (int userId, string email, string cardNumber) FindUserBySearchKey(string searchKey)
        {
            string sqlFindUser = @"
            SELECT user_id, email, card_number
            FROM users
            WHERE email = @SearchKey OR card_number = @SearchKey;
            ";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(sqlFindUser, connection))
                {
                    command.Parameters.AddWithValue("@SearchKey", searchKey);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string email = reader.GetString(1);
                            string cardNumber = reader.GetString(2);
                            return (userId, email, cardNumber);
                        }
                        else
                        {
                            return default;
                        }
                    }
                }
            }
        }

        private void DelUser((int userId, string email, string cardNumber) userInfo)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                connection.Open();

                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удалить записи из всех связанных таблиц
                        DeleteFromTable("balances", "user_id", userInfo.userId, connection, transaction);
                        DeleteFromTable("cashback", "user_id", userInfo.userId, connection, transaction);
                        DeleteFromTable("transactions", "user_id", userInfo.userId, connection, transaction);

                        // Удалить пользователя из таблицы users
                        string sqlDeleteUser = @"
                        DELETE FROM users
                        WHERE user_id = @UserId;
                        ";

                        using (NpgsqlCommand command = new NpgsqlCommand(sqlDeleteUser, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userInfo.userId);
                            command.ExecuteNonQuery();
                        }

                        // Добавление записи в таблицу history
                        AddToHistory(userInfo, connection, transaction);

                        // Фиксация транзакции
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        throw; // Пробросить исключение для обработки в вызывающем коде
                    }
                }
            }
        }

        private void DeleteFromTable(string tableName, string columnName, int userId, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            string sqlDelete = $@"
            DELETE FROM {tableName}
            WHERE {columnName} = @UserId;
            ";

            using (NpgsqlCommand command = new NpgsqlCommand(sqlDelete, connection, transaction))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.ExecuteNonQuery();
            }
        }

        private void AddToHistory((int userId, string email, string cardNumber) userInfo, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            string sqlInsertHistory = @"
            INSERT INTO history (user_id, email, card_number, action)
            VALUES (@UserId, @Email, @CardNumber, 'User Deleted');
            ";

            using (NpgsqlCommand insertHistoryCommand = new NpgsqlCommand(sqlInsertHistory, connection, transaction))
            {
                insertHistoryCommand.Parameters.AddWithValue("@UserId", userInfo.userId);
                insertHistoryCommand.Parameters.AddWithValue("@Email", userInfo.email);
                insertHistoryCommand.Parameters.AddWithValue("@CardNumber", userInfo.cardNumber);
                insertHistoryCommand.ExecuteNonQuery();
            }
        }
    }
}
