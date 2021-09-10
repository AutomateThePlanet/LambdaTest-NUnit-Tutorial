using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NUnitPageObjects.Version3
{
    public class HomePage : WebPage
    {
        public HomePage(IWebDriver driver, WebDriverWait wait, Actions actions)
            : base(driver, wait, actions)
        {
        }

        protected override string Url => "https://todomvc.com/";

        public void OpenTechnologyApp(string name)
        {
            var technologyLink = WaitAndFindElement(By.LinkText(name));
            technologyLink.Click();
        }
    }
}
