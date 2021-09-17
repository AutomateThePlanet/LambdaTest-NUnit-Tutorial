using OpenQA.Selenium;

namespace NUnitPageObjects.Version2
{
    public partial class MainPage : WebPage
    {
        public MainPage(IWebDriver driver) 
            : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart(string rocketName)
        {
            GoTo();
            GetProductBoxByName(rocketName).Click();
            ViewCartButton.Click();
        }

        protected override void WaitForPageToLoad()
        {
            WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
        }
    }
}
