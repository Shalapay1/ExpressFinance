using System;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ExpressFinance
{
    public partial class LoginForm : Form
    {

        public string sqlConnect = "Server=localhost;Port=5432;Database=ExpressFinanceDB; User ID = postgres; Password=563421;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private async Task<int> SQLConnect(string email, string password)
        {
            int userId = -1; // значення за замовчуванням, якщо користувач не знайдений
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlConnect);
                npgsqlConnection.Open();
                string query = "SELECT user_id, user_role FROM users WHERE email = @Email AND password = @Password;";
                NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader["user_id"]);
                    string userRole = reader["user_role"].ToString();
                    if (userRole == "admin")
                    {
                        // Відкрийте адміністраторську панель
                        AdminPanel adminPanel = new AdminPanel(userId, sqlConnect);
                        this.Hide();
                        adminPanel.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Відкрийте панель користувача
                        UserPanel userPanel = new UserPanel(userId, sqlConnect); // передайте userId у конструктор UserPanel
                        this.Hide();
                        userPanel.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    // Помилка входу
                    MessageBox.Show("Неправильний email або пароль. Будь ласка, спробуйте знову.", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                npgsqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Помилка, {e}", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e);
            }
            return userId; // Повернути userId
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            // Отримати введені дані користувача
            string email = textBox1.Text;
            string password = textBox2.Text;

            // Перевірка введених даних для входу            
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // Виклик функції підключення до бази даних
                SQLConnect(email, password);
            }
            else
            {
                // Помилка входу
                MessageBox.Show("Введіть email та пароль.", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка, что вводятся только цифры и управляющие символы (например, backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отклоняем ввод
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем максимальную длину текста для текстового поля
            textBox2.MaxLength = 4;
            // Подписываемся на событие KeyPress для фильтрации вводимых символов
            textBox2.KeyPress += tpassword_KeyPress;
            // Подключение обработчика события KeyPress
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешенные символы: украинские буквы и пробел
            string allowedChars = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";

            // Проверка введенного символа
            if (!allowedChars.Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Отклонить символ
            }
        }

    }
}
