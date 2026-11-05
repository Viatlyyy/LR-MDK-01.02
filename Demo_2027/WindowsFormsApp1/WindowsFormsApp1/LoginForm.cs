using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form, IAuthorizationView
    {
        private AuthorizationPresenter authorizationPresenter_;

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(IAuthorization authorization) : this()
        {
            authorizationPresenter_ = new AuthorizationPresenter(authorization, this);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Login
        {
            get { return LoginTextBox.Text; }
            set { LoginTextBox.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            if (authorizationPresenter_ == null)
            {
                authorizationPresenter_ = new AuthorizationPresenter(new Authorization(), this);
            }

            authorizationPresenter_.Authorize();
        }

        private void GuestLoginButton_Click(object sender, EventArgs e)
        {
            AuthorizedUser = null;
            DialogResult = DialogResult.OK;
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
        }
    }
}
