using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitPageObjects.Version1
{
    public class ToDoPage
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;
        private Actions _actions;

        public ToDoPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _webDriverWait = wait;
            _actions = actions;
        }

        // Elements
        public IWebElement ToDoInput 
        { 
            get
            {
                return WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            }
        }

        public IWebElement ResultSpan => WaitAndFindElement(By.XPath("//footer/span"));

        public IWebElement GetItemCheckBox(string todoItem)
        {
            return WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
        }

        // Actions
        public void AddNewToDoItem(string todoItem)
        {
            ToDoInput.SendKeys(todoItem);
            _actions.Click(ToDoInput).SendKeys(Keys.Enter).Perform();
        }

        public void CheckItem(string itemName)
        {
            GetItemCheckBox(itemName).Click();
        }

        // Assertions
        public void AssertLeftItems(int expectedCount)
        {
            if (expectedCount <= 0)
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} item left");
            }
            else
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} items left");
            }
        }

        private void ValidateInnerTextIs(IWebElement element, string expectedText)
        {
            _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(element, expectedText));
        }

        private IWebElement WaitAndFindElement(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
