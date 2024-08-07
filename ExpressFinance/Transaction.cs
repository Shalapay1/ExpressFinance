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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpressFinance
{
    public partial class Transaction : Form
    {
        private int userId;
        private string sqlConnect;
        public Transaction(int userId, string sqlConnect)
        {
            InitializeComponent();
            this.userId = userId; // Зберегти ID користувача
            this.sqlConnect = sqlConnect;
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            // SQL-запрос для выборки данных о транзакциях с заменой user_id и receiver_id на соответствующие им email из таблицы users
            string sqlQuery = @"
                    SELECT 
                        t.transaction_id,
                        u_sender.email as sender_email,
                        u_receiver.email as receiver_email,
                        t.amount,
                        t.transaction_date
                    FROM 
                        transactions t
                    JOIN 
                        users u_sender ON t.user_id = u_sender.user_id
                    JOIN 
                        users u_receiver ON t.receiver_id = u_receiver.user_id
                    ORDER BY 
                        t.transaction_date DESC;
                ";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
            {
                try
                {
                    connection.Open();

                    // Создаем адаптер данных и заполняем DataTable
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sqlQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Привязываем DataTable к DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Делаем некоторые настройки DataGridView, например, скрываем столбец с идентификатором транзакции
                    dataGridView1.Columns["transaction_id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка під час завантаження даних про транзакції: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string userEmail = tSearch.Text.Trim(); // Получаем введенный email пользователя

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Введіть email користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL-запрос для выбора транзакций пользователя по email
                        string sqlQueryTransactions = @"
                    SELECT 
                        transaction_id,
                        sender.email as sender_email,
                        receiver.email as receiver_email,
                        amount,
                        transaction_date
                    FROM 
                        transactions
                    INNER JOIN
                        users as sender ON transactions.user_id = sender.user_id
                    INNER JOIN
                        users as receiver ON transactions.receiver_id = receiver.user_id
                    WHERE 
                        sender.email = @Email OR receiver.email = @Email
                    ORDER BY 
                        transaction_date DESC;
                ";

                // Выполняем SQL-запрос
                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sqlQueryTransactions, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Email", userEmail);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Отображаем результат в DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження транзакцій користувача: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
