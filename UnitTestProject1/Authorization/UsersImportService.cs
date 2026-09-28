using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    public class UsersImportService
    {
        private readonly IUsersFile file_;
        private readonly IUsersRepository repository_;

        public UsersImportService(IUsersFile file, IUsersRepository repository)
        {
            file_ = file;
            repository_ = repository;
        }

        public int ImportUsers()
        {
            List<User> users = file_.ReadUsers();
            if (users == null)
            {
                throw new InvalidDataException("Файл не содержит список пользователей.");
            }

            List<User> existingUsers = repository_.GetAllUsers();
            if (existingUsers == null)
            {
                throw new InvalidDataException("Не удалось получить пользователей из БД.");
            }

            var logins = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (User existingUser in existingUsers)
            {
                if (existingUser == null || string.IsNullOrWhiteSpace(existingUser.Login) ||
                    !logins.Add(existingUser.Login))
                {
                    throw new InvalidDataException("В БД обнаружены некорректные или повторяющиеся логины.");
                }
            }

            foreach (User user in users)
            {
                if (user == null ||
                    string.IsNullOrWhiteSpace(user.Login) ||
                    string.IsNullOrWhiteSpace(user.Password) ||
                    user.Password.Length < 8 ||
                    string.IsNullOrWhiteSpace(user.Name) ||
                    string.IsNullOrWhiteSpace(user.Familia))
                {
                    throw new InvalidDataException("В файле обнаружен некорректный пользователь.");
                }

                if (!logins.Add(user.Login))
                {
                    throw new InvalidDataException("Логин уже существует в файле или БД.");
                }
            }

            foreach (User user in users)
            {
                repository_.SetUser(user);
            }

            return users.Count;
        }
    }
}
