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
            int userId = -1; // �������� �� �������������, ���� ���������� �� ���������
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
                        // ³������� ��������������� ������
                        AdminPanel adminPanel = new AdminPanel(userId, sqlConnect);
                        this.Hide();
                        adminPanel.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // ³������� ������ �����������
                        UserPanel userPanel = new UserPanel(userId, sqlConnect); // ��������� userId � ����������� UserPanel
                        this.Hide();
                        userPanel.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    // ������� �����
                    MessageBox.Show("������������ email ��� ������. ���� �����, ��������� �����.", "������� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                npgsqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"�������, {e}", "������� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e);
            }
            return userId; // ��������� userId
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            // �������� ������ ��� �����������
            string email = textBox1.Text;
            string password = textBox2.Text;

            // �������� �������� ����� ��� �����            
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // ������ ������� ���������� �� ���� �����
                SQLConnect(email, password);
            }
            else
            {
                // ������� �����
                MessageBox.Show("������ email �� ������.", "������� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������, ��� �������� ������ ����� � ����������� ������� (��������, backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ��������� ����
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // ������������� ������������ ����� ������ ��� ���������� ����
            textBox2.MaxLength = 4;
            // ������������� �� ������� KeyPress ��� ���������� �������� ��������
            textBox2.KeyPress += tpassword_KeyPress;
            // ����������� ����������� ������� KeyPress
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ����������� �������: ���������� ����� � ������
            string allowedChars = "��������賿�����������������������å�Ū��Ȳ��������������������� ";

            // �������� ���������� �������
            if (!allowedChars.Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // ��������� ������
            }
        }

    }
}
