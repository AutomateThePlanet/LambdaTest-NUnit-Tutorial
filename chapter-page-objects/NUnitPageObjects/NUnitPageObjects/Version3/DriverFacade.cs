using System;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitPageObjects.Version3
{
    public class DriverFacade
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

        public static void Start(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                    Driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.Latest);
                    Driver = new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.Latest);
                    Driver = new EdgeDriver();
                    break;
                case BrowserType.Opera:
                    new DriverManager().SetUpDriver(new OperaConfig(), VersionResolveStrategy.Latest);
                    Driver = new OperaDriver();
                    break;
                case BrowserType.Safari:
                    Driver = new SafariDriver();
                    break;
            }

            Driver.Manage().Window.Maximize();
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public static IWebDriver Driver { get; set; }
        public static WebDriverWait WebDriverWait { get; set; }

        public static IWebElement WaitAndFindElement(By locator)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public static void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static void GoTo(string url, Action waitForPageToLoad)
        {
            Driver.Navigate().GoToUrl(url);
            waitForPageToLoad();
        }

        public static void Quit()
        {
            Driver.Quit();
        }
    }
}
