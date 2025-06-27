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
        public void DangNhapThanhCong()
        {
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[1]/div[1]/div[4]/div")).Click();
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("ngocduy1423@gmail.com");
            driver.FindElement(By.XPath("//*[@id='root']/div/div/div/div/div[2]/div/div[2]/div/div/div[2]/span/input")).SendKeys("Duy123123123");

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