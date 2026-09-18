using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class UserService
    {
        IUserRepository userRepository_;
        public UserService(IUserRepository userRepository)
        {
            userRepository_ = userRepository;
        }
        public bool Autorization(string login, string password)
        {
            User user = userRepository_.GetUserByLogin(login);
            if (user.Password == password && user.Login == login)
            {
                return true;
            }
            return false;

        }
    }
}
