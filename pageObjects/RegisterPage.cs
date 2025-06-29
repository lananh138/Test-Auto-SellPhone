using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Test;


namespace TestProject.PageObjects
{
    public class RegisterPage : TestBase
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly By emailField = By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[1]/input");
        private readonly By passwordField = By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[2]/span/input");
        private readonly By confirmPasswordField = By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[3]/span/input");
        private readonly By registerButton = By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[4]/div/div/button");

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void EnterEmail(string email)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(emailField)).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(confirmPasswordField)).SendKeys(confirmPassword);
        }

        public void ClickRegisterButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(registerButton)).Click();
            System.Threading.Thread.Sleep(3000);
        }
        public void IsRegisterSuccessful()
        {
            var elements = driver.FindElements(By.XPath("//*[@id='root']/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[3]/span/input"));

            if (elements.Count == 0)
            {
                Console.WriteLine("Đăng ký thành công!", elements.Count);

            }
            else
            {
                Console.WriteLine("Đăng ký thất bại!", elements.Count);
            }
        }

    }
}