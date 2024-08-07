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
    public partial class AdminPanel : Form
    {
        private int userId;
        private string sqlConnect;
        public AdminPanel(int userId, string sqlConnect)
        {
            InitializeComponent();
            this.userId = userId; // Зберегти ID користувача
            this.sqlConnect = sqlConnect;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                // Запрос для отображения информации о пользователе
                string sqlUserInfo = "SELECT u.email FROM users u JOIN balances b ON u.user_id = b.user_id WHERE u.user_id = @UserId";

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
                                string email = reader["email"].ToString();

                                lblEmail.Text = $"Email: {email}";
                            }
                            else
                            {
                                MessageBox.Show("Користувач не знайдений.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bDeletUsr_Click(object sender, EventArgs e)
        {
            DeleteUser delete = new DeleteUser(userId, sqlConnect);
            delete.ShowDialog();
        }

        private void bTransacs_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(userId, sqlConnect);
            transaction.ShowDialog();
        }

        private void bAddUsr_Click(object sender, EventArgs e)
        {
            AddUser added = new AddUser(userId, sqlConnect);
            added.ShowDialog();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void bHistory_Click(object sender, EventArgs e)
        {
            History added = new History(sqlConnect);
            added.ShowDialog();
        }
    }
}
