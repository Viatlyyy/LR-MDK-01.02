using System;
using System.Configuration;
using System.Windows.Forms;
using DemoLib.Data;
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

            DatabaseHelper database = new DatabaseHelper(connectionString);
            IOrdersRepository ordersRepository = new PostgresOrdersRepository(database);
            MainForm mainForm = new MainForm(database, ordersRepository);
            mainForm.CurrentUser = user;
            Application.Run(mainForm);
        }
    }
}
