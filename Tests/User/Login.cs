using main.Test;
using Test;
using Test.PageObjects;

namespace main.Test.Tests.User
{
    public class Login : TestBase
    {
        [Test]
        public void DangNhapThanhCong()
        {
            Thread.Sleep(2000); // Wait for the page to load
            LoginPage loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
            loginPage.EnterEmail("Ngocduy14062003@gmail.com");
            loginPage.EnterPassword("Duy123");
            loginPage.ClickLoginButton();
        }

        [Test]
        public void DangNhapThatbai()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
            loginPage.EnterEmail("Ngocduy14062003@gmail.com");
            loginPage.EnterPassword("Duy123");
            loginPage.ClickLoginButton();
        }
    }
}