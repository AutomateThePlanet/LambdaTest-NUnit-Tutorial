using OpenQA.Selenium;

namespace NUnitPageObjects.Version2
{
    public partial class CartPage : WebPage
    {
        public CartPage(IWebDriver driver) 
            : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public void ApplyCoupon(string coupon)
        {
            QuantityBox.Clear();
            CouponCodeTextField.SendKeys(coupon);
            ApplyCouponButton.Click();
            WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.Clear();
            QuantityBox.SendKeys(newQuantity.ToString());
            UpdateCart.Click();
            WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            ProceedToCheckoutButton.Click();
            WaitUntilPageLoadsCompletely();
        }

        public string GetTotal()
        {
            return TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return MessageAlert.Text;
        }

        protected override void WaitForPageToLoad()
        {
            WaitAndFindElement(By.Id("coupon_code"));
        }
    }
}
