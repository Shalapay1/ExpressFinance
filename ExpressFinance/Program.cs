using System;
using System.Windows.Forms;

namespace ExpressFinance
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ������� � ���������� ����� �����-������
            Welcome splashScreen = new Welcome();

            // ��������� ������ ��� ��������
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; // 3000 ����������� = 3 �������
            timer.Tick += (s, e) =>
            {
                // ������������� ������
                timer.Stop();
                // ��������� �����-�����
                splashScreen.Close();
            };

            timer.Start();

            // ���������� �����-����� ��������
            splashScreen.ShowDialog();

            // ���������� ������� ����� ��������� ����� �������� �����-������
            Application.Run(new LoginForm());
        }
    }
}
