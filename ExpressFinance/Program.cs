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

            // Создаем и отображаем форму сплэш-скрина
            Welcome splashScreen = new Welcome();

            // Запускаем таймер для задержки
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; // 3000 миллисекунд = 3 секунды
            timer.Tick += (s, e) =>
            {
                // Останавливаем таймер
                timer.Stop();
                // Закрываем сплэш-скрин
                splashScreen.Close();
            };

            timer.Start();

            // Отображаем сплэш-скрин модально
            splashScreen.ShowDialog();

            // Отображаем главную форму программы после закрытия сплэш-скрина
            Application.Run(new LoginForm());
        }
    }
}
