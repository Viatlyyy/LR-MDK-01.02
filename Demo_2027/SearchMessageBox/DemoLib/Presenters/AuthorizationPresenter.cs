using DemoLib.Models;
using DemoLib.Views;

namespace DemoLib.Presenters
{
    public class AuthorizationPresenter
    {
        private IAuthorization authorization_;
        private IAuthorizationView view_;

        public AuthorizationPresenter(IAuthorization authorization, IAuthorizationView view)
        {
            authorization_ = authorization;
            view_ = view;
        }

        public void Authorize()
        {
            User user = authorization_.Authorize(view_.Login);
            if (user == null)
            {
                view_.ShowError("Пользователь с таким логином не найден.");
                return;
            }

            view_.CompleteAuthorization(user);
        }
    }
}
