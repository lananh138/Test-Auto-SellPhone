using main.Test;
using Test;
using TestProject.PageObjects;
using OpenQA.Selenium;

namespace main.Test.Tests.User
{
    [TestFixture]
    public class Login : TestBase
    {

        [Category("Login")]
        [TestCase("nguyenthilananh113388@gmail.com", "Llananh", TestName = "Login1")]
        [TestCase("nguyenthilananh@gmail.com", "123456A", TestName = "Login2")]
        public void Fun_Login(string email, string password)
        {
            //jkj
            LoginPage loginPage = new LoginPage(driver);
            driver.FindElement(By.XPath("//*[@id='root']/div[1]/div/div/div/div[1]/div[1]/div[4]/div")).Click();
            loginPage.EnterUsername(email);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            loginPage.IsLoginSuccessful();

        }
      
    }
}