using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class MainPage
    {
        public static IWebElement AddToCartFalcon9 => DriverFacade.WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
        public static IWebElement ViewCartButton => DriverFacade.WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public static IWebElement GetProductBoxByName(string name)
        {
            return DriverFacade.WaitAndFindElement(By.XPath($"//h2[text()='{name}']/parent::a/following-sibling::a"));
        }
    }
}
