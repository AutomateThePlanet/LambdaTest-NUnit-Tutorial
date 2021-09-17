using OpenQA.Selenium;

namespace NUnitPageObjects.Version2
{
    public partial class MainPage
    {
        public IWebElement AddToCartFalcon9 => WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
        public IWebElement ViewCartButton => WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public IWebElement GetProductBoxByName(string name)
        {
            return WaitAndFindElement(By.XPath($"//h2[text()='{name}']/parent::a/following-sibling::a"));
        }
    }
}
