using DemoLib.Models;

namespace DemoLib.Views
{
    public interface IAuthorizationView
    {
        string Login { get; set; }
        void ShowError(string message);
        void CompleteAuthorization(User user);
    }
}
