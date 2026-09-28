using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace _150926
{
    [TestClass]
    public class TUsersImportService
    {
        [TestMethod]
        public void ImportUsers_SavesAllUsersAndReportsCount()
        {
            var users = new List<User>
            {
                new User { Login = "anna", Password = "password1", Name = "Anna", Familia = "Ivanova" },
                new User { Login = "boris", Password = "password2", Name = "Boris", Familia = "Petrov" }
            };
            var savedUsers = new List<User>();
            var file = new Mock<IUsersFile>();
            file.Setup(source => source.ReadUsers()).Returns(users);
            var database = new Mock<IUsersRepository>();
            database.Setup(store => store.GetAllUsers()).Returns(savedUsers);
            database.Setup(store => store.SetUser(It.IsAny<User>()))
                .Callback<User>(savedUsers.Add);

            int imported = new UsersImportService(file.Object, database.Object).ImportUsers();

            Assert.AreEqual(2, imported);
            CollectionAssert.AreEqual(users, savedUsers);
            file.Verify(source => source.ReadUsers(), Times.Once);
        }

        [TestMethod]
        public void ImportUsers_RejectsMissingRequiredFieldBeforeSaving()
        {
            var users = new List<User>
            {
                new User { Login = "anna", Password = "password1", Name = "Anna", Familia = "Ivanova" },
                new User { Login = "boris", Password = "password2", Name = "", Familia = "Petrov" }
            };
            var file = new Mock<IUsersFile>();
            file.Setup(source => source.ReadUsers()).Returns(users);
            var database = new Mock<IUsersRepository>();
            database.Setup(store => store.GetAllUsers()).Returns(new List<User>());

            Assert.ThrowsException<InvalidDataException>(() =>
                new UsersImportService(file.Object, database.Object).ImportUsers());
            database.Verify(store => store.SetUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public void ImportUsers_RejectsShortPasswordBeforeSaving()
        {
            var file = new Mock<IUsersFile>();
            file.Setup(source => source.ReadUsers()).Returns(new List<User>
            {
                new User { Login = "anna", Password = "short", Name = "Anna", Familia = "Ivanova" }
            });
            var database = new Mock<IUsersRepository>();
            database.Setup(store => store.GetAllUsers()).Returns(new List<User>());

            Assert.ThrowsException<InvalidDataException>(() =>
                new UsersImportService(file.Object, database.Object).ImportUsers());
            database.Verify(store => store.SetUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public void ImportUsers_RejectsDuplicateLoginInFileBeforeSaving()
        {
            var file = new Mock<IUsersFile>();
            file.Setup(source => source.ReadUsers()).Returns(new List<User>
            {
                new User { Login = "anna", Password = "password1", Name = "Anna", Familia = "Ivanova" },
                new User { Login = "ANNA", Password = "password2", Name = "Anya", Familia = "Petrova" }
            });
            var database = new Mock<IUsersRepository>();
            database.Setup(store => store.GetAllUsers()).Returns(new List<User>());

            Assert.ThrowsException<InvalidDataException>(() =>
                new UsersImportService(file.Object, database.Object).ImportUsers());
            database.Verify(store => store.SetUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public void ImportUsers_RejectsLoginAlreadyInDatabaseBeforeSaving()
        {
            var file = new Mock<IUsersFile>();
            file.Setup(source => source.ReadUsers()).Returns(new List<User>
            {
                new User { Login = "ANNA", Password = "password1", Name = "Anna", Familia = "Ivanova" }
            });
            var database = new Mock<IUsersRepository>();
            database.Setup(store => store.GetAllUsers()).Returns(new List<User>
            {
                new User { Login = "anna", Password = "password0", Name = "Old", Familia = "User" }
            });

            Assert.ThrowsException<InvalidDataException>(() =>
                new UsersImportService(file.Object, database.Object).ImportUsers());
            database.Verify(store => store.SetUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public void ImportUsers_RejectsMissingFileData()
        {
            var file = new Mock<IUsersFile>();
            var database = new Mock<IUsersRepository>();

            Assert.ThrowsException<InvalidDataException>(() =>
                new UsersImportService(file.Object, database.Object).ImportUsers());
            database.Verify(store => store.SetUser(It.IsAny<User>()), Times.Never);
        }
    }
}
