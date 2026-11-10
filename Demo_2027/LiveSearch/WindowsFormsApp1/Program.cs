using System;
using System.Configuration;
using System.Windows.Forms;
using DemoLib.Repositories;
using DemoLib.Models;

namespace WindowsFormsApp1
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            User user;
            IAuthorization authorization = new Authorization();
            using (LoginForm loginForm = new LoginForm(authorization))
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                user = loginForm.AuthorizedUser;
            }
            string connectionString = Environment.GetEnvironmentVariable("CHUDO_OBUV_POSTGRES");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["ChudoObuv"]?.ConnectionString;
            }

            IOrdersRepository ordersRepository = new PostgresOrdersRepository(connectionString);
            MainForm mainForm = new MainForm(connectionString, ordersRepository);
            mainForm.CurrentUser = user;
            Application.Run(mainForm);
        }
    }
}
