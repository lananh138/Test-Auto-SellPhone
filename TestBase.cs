namespace Test;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
public class TestBase
{
    protected IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        var options = new ChromeOptions();

        // BỎ QUA lỗi SSL
        // options.AcceptInsecureCertificates = true;
        // options.AddArgument("--ignore-certificate-errors");
        // options.AddArgument("--allow-insecure-localhost");

        // Dành cho macOS: chỉ định rõ binary nếu cần
        if (System.Runtime.InteropServices.RuntimeInformation
            .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
        {
            options.BinaryLocation = "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome";
        }

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("http://localhost:5085/");
    }




    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}