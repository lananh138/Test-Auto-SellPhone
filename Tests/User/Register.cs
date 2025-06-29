using Test;
using TestProject.PageObjects;
using OpenQA.Selenium;
using testauto.Test.Utilities;
namespace main.Test.Tests.User
{
    [TestFixture]
    public class Register : TestBase
    {
        // [TestCase("ngthiFlafddfnanh12gfdsfgfgggghfgfgft3454444447@gmail.com", "123456A", "123456A", TestName = "Register1")]
        // [TestCase("", "123456A", "123456A", TestName = "Register2")]
        // [TestCase("nguyenthilananh1234567@gmail.com", "123456A", "123456A", TestName = "Register3")]
        [Test, TestCaseSource(typeof(ExcelReportHelper), nameof(ExcelReportHelper.RegisterTestCases))]
        [Category("Register")]

        public void Fun_Register(string email, string password, string repassword)
        {
            RegisterPage registerPage = new RegisterPage(driver);
            driver.FindElement(By.XPath("//*[@id='root']/div[1]/div/div/div/div[1]/div[1]/div[4]/div")).Click();
            driver.FindElement(By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[1]/div/div/div/label[2]/span[2]")).Click();
            registerPage.EnterEmail(email);
            registerPage.EnterPassword(password);
            registerPage.EnterConfirmPassword(repassword);
            registerPage.ClickRegisterButton();
            registerPage.IsRegisterSuccessful();
            ExcelReportHelper.WriteToExcel("Register", "Register", "Pass", $"Email: {email}, Password: {password}, RePassword: {repassword}");
        }
    }
}