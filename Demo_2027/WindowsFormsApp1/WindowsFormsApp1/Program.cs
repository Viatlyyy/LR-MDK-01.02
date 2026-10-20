using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                if (loginForm.ShowDialog() != DialogResult.OK || loginForm.AuthorizedUser == null)
                {
                    return;
                }
                user = loginForm.AuthorizedUser;
            }
            IOrdersRepository ordersRepository = new DemoOrdersRepository();
            MainForm mainForm = new MainForm(ordersRepository);
            mainForm.CurrentUser = user;
            Application.Run(mainForm);
        }
    }
}
