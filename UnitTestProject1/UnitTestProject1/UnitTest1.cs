using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("123"))
                .Returns(new User { Login = "123", Password = "12345" });
            IUserRepository userRepository = mock.Object;
            UserService userService = new UserService (userRepository);
            bool flag = userService.Autorization("123", "12345");
            Assert.IsTrue(flag);
        }
    }
}
