using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Views;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form, IAuthorizationView
    {
        private AuthorizationPresenter authorizationPresenter_;

        public LoginForm()
        {
            InitializeComponent();
            authorizationPresenter_ = new AuthorizationPresenter(new Authorization(), this);
        }

        public LoginForm(IAuthorization authorization)
        {
            InitializeComponent();
            authorizationPresenter_ = new AuthorizationPresenter(authorization, this);
        }

        public string Login
        {
            get { return LoginTextBox.Text; }
            set { LoginTextBox.Text = value; }
        }

        public User AuthorizedUser { get; set; }

        public void ShowError(string message)
        {
            ErrorLabel.Text = message;
            LoginTextBox.Focus();
            LoginTextBox.SelectAll();
        }

        public void CompleteAuthorization(User user)
        {
            AuthorizedUser = user;
            DialogResult = DialogResult.OK;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            authorizationPresenter_.Authorize();
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
        }
    }
}
