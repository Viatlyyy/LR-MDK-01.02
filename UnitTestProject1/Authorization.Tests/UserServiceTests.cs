using System;
using Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Authorization.Tests
{
    [TestClass]
    public class UserServiceTests
    {

        [TestMethod]
        public void Autorization_WithCorrectCredentials()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("123"))
                .Returns(new User { Login = "123", Password = "12345" });
            IUserRepository userRepository = mock.Object;
            UserService userService = new UserService (userRepository);
            bool flag = userService.Autorization("123", "12345");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Autorization_WithIncorrectPassword()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("123"))
                .Returns(new User { Login = "123", Password = "12345" });
            IUserRepository userRepository = mock.Object;
            UserService userService = new UserService(userRepository);

            bool flag = userService.Autorization("123", "wrongPassword");

            Assert.IsFalse(flag);
        }
    }
}
