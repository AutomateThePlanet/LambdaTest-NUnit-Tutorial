using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class CartPage
    {
        public static IWebElement CouponCodeTextField => DriverFacade.WaitAndFindElement(By.Id("coupon_code"));
        public static IWebElement ApplyCouponButton => DriverFacade.WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
        public static IWebElement QuantityBox => DriverFacade.WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
        public static IWebElement UpdateCart => DriverFacade.WaitAndFindElement(By.CssSelector("[value*='Update cart']"));
        public static IWebElement MessageAlert => DriverFacade.WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
        public static IWebElement TotalSpan => DriverFacade.WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
        public static IWebElement ProceedToCheckoutButton => DriverFacade.WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
    }
}
