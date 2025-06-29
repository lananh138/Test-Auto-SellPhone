using Test;
using TestProject.PageObjects;
using OpenQA.Selenium;
using testauto.Test.Utilities;
using main.Test.Helpers;
namespace main.Test.Tests.User
{
    [TestFixture]
    public class Register : TestBase
    {
        // [TestCase("ngthiFlafddfnanh12gfdsfgfgggghfgfgft3454444447@gmail.com", "123456A", "123456A", TestName = "Register1")]
        // [TestCase("", "123456A", "123456A", TestName = "Register2")]
        [TestCase("Quản lý tài khoản", "ID_Register_1", TestName = "Register1")]
        [TestCase("Quản lý tài khoản", "ID_Register_2", TestName = "Register2")]
        [TestCase("Quản lý tài khoản", "ID_Register_3", TestName = "Register3")]
        [TestCase("Quản lý tài khoản", "ID_Register_4", TestName = "Register4")]
        [Category("Register")]

        public void Fun_Register(string worksheets, string numberTest)
        {
            string data = ReadTestDataToExcel.ReadDataToExcel(worksheets, numberTest);
            string[] values = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string email = values[0];
            string password = values[1];
            string confirmPassword = values[2];

            RegisterPage registerPage = new RegisterPage(driver);
            driver.FindElement(By.XPath("//*[@id='root']/div[1]/div/div/div/div[1]/div[1]/div[4]/div")).Click();
            driver.FindElement(By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[1]/div/div/div/label[2]/span[2]")).Click();
            registerPage.EnterEmail(email);
            registerPage.EnterPassword(password);
            registerPage.EnterConfirmPassword(confirmPassword);
            registerPage.ClickRegisterButton();
            ;
            if (registerPage.IsRegisterSuccessful())
            {
                ExcelReportHelper.WriteToExcel(
                worksheets,
                numberTest,
                "Pass",
                $"Đăng ký thành công với email: {email}"
            );
            }
            else
            {
                ExcelReportHelper.WriteToExcel(
                worksheets,
                numberTest,
                "False",
                $"Đăng ký thất bại với email: {email}"
            );
            }

        }
    }
}