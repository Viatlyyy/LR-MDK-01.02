using DemoLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTesting
{
    [TestClass]
    public class TAuthorization
    {
        [TestMethod]
        public void Authorize_KnownLogin_ReturnsMatchingUser()
        {
            Authorization authorization = new Authorization();

            User user = authorization.Authorize("isivanov");

            Assert.IsNotNull(user);
            Assert.AreEqual("isivanov", user.Login);
            Assert.AreEqual("Иванов Иван Сергеевич", user.FullName);
            Assert.AreEqual("Администратор", user.Role);
        }

        [TestMethod]
        public void Authorize_UnknownLogin_ReturnsNull()
        {
            Authorization authorization = new Authorization();

            User user = authorization.Authorize("unknown-user");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void Authorize_EmptyLogin_ReturnsNull()
        {
            Authorization authorization = new Authorization();

            User user = authorization.Authorize("");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void Authorize_NullLogin_ReturnsNull()
        {
            Authorization authorization = new Authorization();

            User user = authorization.Authorize(null);

            Assert.IsNull(user);
        }
    }
}
