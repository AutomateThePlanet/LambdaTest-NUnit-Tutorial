using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class CartPage
    {
        public static void GoTo()
        {
            DriverFacade.GoTo("http://demos.bellatrix.solutions/cart/", () => DriverFacade.WaitAndFindElement(By.Id("coupon_code")));
        }

        public static void ApplyCoupon(string coupon)
        {
            QuantityBox.Clear();
            CouponCodeTextField.SendKeys(coupon);
            ApplyCouponButton.Click();
            DriverFacade.WaitForAjax();
        }

        public static void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.Clear();
            QuantityBox.SendKeys(newQuantity.ToString());
            UpdateCart.Click();
            DriverFacade.WaitForAjax();
        }

        public static void ProceedToCheckout()
        {
            ProceedToCheckoutButton.Click();
            DriverFacade.WaitUntilPageLoadsCompletely();
        }

        public static string GetTotal()
        {
            return TotalSpan.Text;
        }

        public static string GetMessageNotification()
        {
            return MessageAlert.Text;
        }
    }
}
