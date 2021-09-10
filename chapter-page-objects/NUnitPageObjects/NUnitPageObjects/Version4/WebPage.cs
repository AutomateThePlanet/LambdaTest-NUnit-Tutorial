using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitPageObjects.Version4
{
    public abstract class WebPage
    {
        public WebPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            Driver = driver;
            WebDriverWait = wait;
            Actions = actions;
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }
        protected Actions Actions { get; set; }

        protected abstract string Url { get; }
        
        public void GoTo()
        {
            WaitForPageToLoad();
            Driver.Navigate().GoToUrl(Url);
        }

        protected virtual void WaitForPageToLoad()
        {
        }

        protected void ValidateInnerTextIs(IWebElement element, string expectedText)
        {
            WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(element, expectedText));
        }

        protected IWebElement WaitAndFindElement(By locator)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
