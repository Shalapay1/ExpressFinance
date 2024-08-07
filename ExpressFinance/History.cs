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
    public partial class History : Form
    {

        private string sqlConnect;
        public History(string sqlConnect)
        {
            InitializeComponent();
            this.sqlConnect = sqlConnect;
            this.Load += new System.EventHandler(this.History_Load);

        }

        private void History_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }

        private void LoadHistoryData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(sqlConnect))
                {
                    connection.Open();
                    string sqlSelectHistory = "SELECT * FROM history;";
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sqlSelectHistory, connection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
