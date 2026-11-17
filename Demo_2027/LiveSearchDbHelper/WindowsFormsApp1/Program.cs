using System;
using System.Windows.Forms;
using DemoLib.Data;
using DemoLib.Repositories;
using DemoLib.Models;

namespace WindowsFormsApp1
{
    public static class Program
    {
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
            DatabaseHelper database = new DatabaseHelper();
            IOrdersRepository ordersRepository = new PostgresOrdersRepository(database);
            MainForm mainForm = new MainForm(database, ordersRepository);
            mainForm.CurrentUser = user;
            Application.Run(mainForm);
        }
    }
}
