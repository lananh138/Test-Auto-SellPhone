namespace Test.PageObjects
{
    using OpenQA.Selenium;

    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:5085/sign-in");
        }

        public void EnterEmail(string email)
        {
            IWebElement usernameField = driver.FindElement(By.XPath("//*[@id=`root`]/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[1]/input"));
            usernameField.Clear();
            usernameField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id=`root`]/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[2]/span/input"));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            var loginButton = driver.FindElement(By.XPath("//*[@id=`root`]/div[1]/div/div/div/div[2]/div/div[2]/div/div/div[3]/div/div/button"));
            loginButton.Click();
        }
    }
}