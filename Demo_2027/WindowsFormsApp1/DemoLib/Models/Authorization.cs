namespace DemoLib.Models
{
    public class Authorization : IAuthorization
    {
        // Пользователи из Users_import.xlsx; на этом этапе данные хранятся в коде.
        private User[] users_ = new User[]
        {
            new User { Login = "isivanov", FullName = "Иванов Иван Сергеевич", Role = "Администратор" },
            new User { Login = "papetrov", FullName = "Петров Пётр Алексеевич", Role = "Менеджер" },
            new User { Login = "asidorova", FullName = "Сидорова Анна Дмитриевна", Role = "Авторизованный пользователь" },
            new User { Login = "ekuznetsova", FullName = "Кузнецова Екатерина Андреевна", Role = "Менеджер" },
            new User { Login = "dsmirnov", FullName = "Смирнов Дмитрий Владимирович", Role = "Авторизованный пользователь" },
            new User { Login = "apopov", FullName = "Попов Алексей Николаевич", Role = "Администратор" },
            new User { Login = "ovasileva", FullName = "Васильева Ольга Игоревна", Role = "Авторизованный пользователь" },
            new User { Login = "psokolov", FullName = "Соколов Павел Викторович", Role = "Менеджер" },
            new User { Login = "tmikhailova", FullName = "Михайлова Татьяна Юрьевна", Role = "Авторизованный пользователь" },
            new User { Login = "nnovikova", FullName = "Новикова Наталья Сергеевна", Role = "Менеджер" },
            new User { Login = "afedorov", FullName = "Фёдоров Андрей Максимович", Role = "Администратор" },
            new User { Login = "smorozov", FullName = "Морозов Сергей Павлович", Role = "Авторизованный пользователь" },
            new User { Login = "jvolkova", FullName = "Волкова Юлия Александровна", Role = "Менеджер" },
            new User { Login = "aalekseev", FullName = "Алексеев Артём Евгеньевич", Role = "Авторизованный пользователь" },
            new User { Login = "ilebedeva", FullName = "Лебедева Ирина Владимировна", Role = "Авторизованный пользователь" },
            new User { Login = "negorov", FullName = "Егоров Никита Денисович", Role = "Менеджер" },
            new User { Login = "epavlova", FullName = "Павлова Елена Петровна", Role = "Авторизованный пользователь" },
            new User { Login = "rkozlov", FullName = "Козлов Роман Олегович", Role = "Администратор" },
            new User { Login = "vstepanova", FullName = "Степанова Виктория Романовна", Role = "Менеджер" },
            new User { Login = "vnikolaev", FullName = "Николаев Владимир Иванович", Role = "Авторизованный пользователь" }
        };

        public User Authorize(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return null;
            }

            login = login.Trim();
            foreach (User user in users_)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
