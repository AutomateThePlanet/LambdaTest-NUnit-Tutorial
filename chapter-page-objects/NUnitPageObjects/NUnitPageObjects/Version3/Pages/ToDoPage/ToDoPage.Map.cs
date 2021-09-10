using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class ToDoPage : WebPage
    {
        private IWebElement ToDoInput => WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));

        private IWebElement ResultSpan => WaitAndFindElement(By.XPath("//footer/span"));

        private IWebElement GetItemCheckBox(string todoItem) => WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
    }
}
