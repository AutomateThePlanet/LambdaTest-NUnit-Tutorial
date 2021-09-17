using OpenQA.Selenium;
using NUnitPageObjects.Version1.Cart;

namespace NUnitPageObjects.Version1
{
    public class CartPage : WebPage
    {
        public CartPage(IWebDriver driver) 
            : base(driver)
        {
            Map = new Map(driver);
            Assertions = new Assertions(Map);
        }

        public Map Map { get; }
        public Assertions Assertions { get; }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public void ApplyCoupon(string coupon)
        {
            Map.QuantityBox.Clear();
            Map.CouponCodeTextField.SendKeys(coupon);
            Map.ApplyCouponButton.Click();
            WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            Map.QuantityBox.Clear();
            Map.QuantityBox.SendKeys(newQuantity.ToString());
            Map.UpdateCart.Click();
            WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            Map.ProceedToCheckout.Click();
            WaitUntilPageLoadsCompletely();
        }

        public string GetTotal()
        {
            return Map.TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return Map.MessageAlert.Text;
        }

        protected override void WaitForPageToLoad()
        {
            WaitAndFindElement(By.Id("coupon_code"));
        }
    }
}
