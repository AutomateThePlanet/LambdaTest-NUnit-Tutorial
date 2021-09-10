using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitPageObjects.Version2
{
    public class ToDoPage : WebPage
    {
        public ToDoPage(IWebDriver driver, WebDriverWait wait, Actions actions)
          : base(driver, wait, actions)
        {
        }

        protected override string Url => "https://todomvc.com/";

        // Elements
        private IWebElement ToDoInput => WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));

        private IWebElement ResultSpan => WaitAndFindElement(By.XPath("//footer/span"));

        private IWebElement GetItemCheckBox(string todoItem) => WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));

        // Actions
        public void AddNewToDoItem(string todoItem)
        {
            ToDoInput.SendKeys(todoItem);
            Actions.Click(ToDoInput).SendKeys(Keys.Enter).Perform();
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
    }
}
