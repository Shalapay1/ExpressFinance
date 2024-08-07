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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ExpressFinance
{
    public partial class UserPanel : Form
    {
        private int userId;
        private string sqlConnect;
        public decimal userBalance;

        public UserPanel(int userId, string sqlConnect)
        {
            InitializeComponent();
            this.userId = userId; // Зберегти ID користувача
            this.sqlConnect = sqlConnect;
        }

        public void UserPanel_Load(object sender, EventArgs e)
        {
            try
            {
                // Запрос для отображения информации о пользователе
                string sqlUserInfo = "SELECT u.card_number, u.email, b.balance FROM users u JOIN balances b ON u.user_id = b.user_id WHERE u.user_id = @UserId";

                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlUserInfo, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string cardNumber = reader["card_number"].ToString();
                                string email = reader["email"].ToString();
                                decimal balance = Convert.ToDecimal(reader["balance"]);

                                lblCardNumber.Text = $"Номер картки: {cardNumber}";
                                lblEmail.Text = $"Email: {email}";
                                lblBalance.Text = $"Баланс: {balance:C}";
                                userBalance = balance;
                            }
                            else
                            {
                                MessageBox.Show("Користувач не знайдений.");
                            }
                        }
                    }
                }
                string sqlTransaction = "SELECT t.amount, t.transaction_date, u.email AS sender_email FROM transactions t JOIN users u ON t.receiver_id = u.user_id WHERE t.user_id = @UserId";

                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlTransaction, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Добавить только столбцы amount, transaction_date и sender_email
                            dataGridTransiction.DataSource = dataTable;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bTransition_Click(object sender, EventArgs e)
        {
            TransferForm transferForm = new TransferForm(userBalance, sqlConnect, userId);
            this.Hide();
            transferForm.ShowDialog();
            this.Close();
        }

        private void bCashback_Click(object sender, EventArgs e)
        {
            Cashback cashback = new Cashback(sqlConnect, userId);
            this.Hide();
            cashback.ShowDialog();
            this.Close();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
