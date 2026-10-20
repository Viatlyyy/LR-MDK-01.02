using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTesting
{
    [TestClass]
    public class TAuthorization
    {
        [DataTestMethod]
        [DataRow("isivanov", "Иванов Иван Сергеевич", "Администратор")]
        [DataRow("papetrov", "Петров Пётр Алексеевич", "Менеджер")]
        [DataRow("vnikolaev", "Николаев Владимир Иванович", "Авторизованный пользователь")]
        public void Authorize_KnownLogin_ReturnsMatchingUser(string login, string fullName, string role)
        {
            IAuthorization authorization = new Authorization();

            User user = authorization.Authorize(login);

            Assert.IsNotNull(user);
            Assert.AreEqual(login, user.Login);
            Assert.AreEqual(fullName, user.FullName);
            Assert.AreEqual(role, user.Role);
        }

        [TestMethod]
        public void Authorize_UnknownLogin_ReturnsNull()
        {
            IAuthorization authorization = new Authorization();

            User user = authorization.Authorize("unknown-user");

            Assert.IsNull(user);
        }

        [DataTestMethod]
        [DataRow((string)null)]
        [DataRow("")]
        [DataRow("   ")]
        public void Authorize_EmptyLogin_ReturnsNull(string login)
        {
            IAuthorization authorization = new Authorization();

            User user = authorization.Authorize(login);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void Authorize_LoginWithOuterSpaces_ReturnsMatchingUser()
        {
            IAuthorization authorization = new Authorization();

            User user = authorization.Authorize("  papetrov  ");

            Assert.IsNotNull(user);
            Assert.AreEqual("papetrov", user.Login);
        }

        [TestMethod]
        public void Presenter_KnownLogin_CompletesAuthorizationWithUser()
        {
            Mock<IAuthorizationView> view = new Mock<IAuthorizationView>();
            view.SetupGet(item => item.Login).Returns("papetrov");
            AuthorizationPresenter presenter = new AuthorizationPresenter(new Authorization(), view.Object);

            presenter.Authorize();

            view.Verify(item => item.CompleteAuthorization(It.Is<User>(user =>
                user.Login == "papetrov" && user.FullName == "Петров Пётр Алексеевич" && user.Role == "Менеджер")), Times.Once());
            view.Verify(item => item.ShowError(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void Presenter_UnknownLogin_ShowsErrorWithoutCompletingAuthorization()
        {
            Mock<IAuthorizationView> view = new Mock<IAuthorizationView>();
            view.SetupGet(item => item.Login).Returns("unknown-user");
            AuthorizationPresenter presenter = new AuthorizationPresenter(new Authorization(), view.Object);

            presenter.Authorize();

            view.Verify(item => item.ShowError(It.Is<string>(message => !string.IsNullOrWhiteSpace(message))), Times.Once());
            view.Verify(item => item.CompleteAuthorization(It.IsAny<User>()), Times.Never());
        }
    }
}
