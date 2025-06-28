using main.Test;
using Test;
using TestProject.PageObjects;
using OpenQA.Selenium;

namespace main.Test.Tests.User
{
    [TestFixture]
    public class Login : TestBase
    {
        [Test]
        [Category("Login")]
        [TestCase("nguyenthilananh1188@gmail.com", "Duy123123123", TestName = "DangNhapThanhCong44")]
        [TestCase("nguyenthilananh1188@gmail.com", "Duy123123123", TestName = "DangNhapThanhCong34")]
        public void DangNhapThanhCong(string email, string password)
        {
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[1]/div[1]/div[4]/div")).Click();
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(email);
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[2]/div/div[2]/div/div/div[2]/span/input")).SendKeys(password);

            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[2]/div/div[2]/div/div/div[3]/div/div/button")).Click();
            Thread.Sleep(5000);
        }
      
        [Test]
        public void DangNhapThatbais()
        {
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[1]/div[1]/div[4]/div")).Click();
        }
    }
}