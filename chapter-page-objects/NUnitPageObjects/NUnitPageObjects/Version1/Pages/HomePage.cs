using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitPageObjects.Version1
{
    public class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;
        private Actions _actions;

        public HomePage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _webDriverWait = wait;
            _actions = actions;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://todomvc.com/");
        }

        public void OpenTechnologyApp(string name)
        {
            var technologyLink = WaitAndFindElement(By.LinkText(name));
            technologyLink.Click();
        }

        private IWebElement WaitAndFindElement(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
