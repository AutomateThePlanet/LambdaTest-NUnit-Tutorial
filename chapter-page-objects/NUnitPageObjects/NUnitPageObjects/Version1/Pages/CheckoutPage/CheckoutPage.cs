using NUnitPageObjects.Version1.Checkout;
using OpenQA.Selenium;

namespace NUnitPageObjects.Version1
{
    public class CheckoutPage : WebPage
    {
        public CheckoutPage(IWebDriver driver) 
            : base(driver)
        {
            Map = new Map(driver);
            Assertions = new Assertions(Map);
        }

        public Map Map { get; }
        public Assertions Assertions { get; }

        protected override string Url => "https://demos.bellatrix.solutions/cart/";

        public void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            Map.BillingFirstName.SendKeys(purchaseInfo.FirstName);
            Map.BillingLastName.SendKeys(purchaseInfo.LastName);
            Map.BillingCompany.SendKeys(purchaseInfo.Company);
            Map.BillingCountryWrapper.Click();
            Map.BillingCountryFilter.SendKeys(purchaseInfo.Country);
            Map.GetCountryOptionByName(purchaseInfo.Country).Click();
            Map.BillingAddress1.SendKeys(purchaseInfo.Address1);
            Map.BillingAddress2.SendKeys(purchaseInfo.Address2);
            Map.BillingCity.SendKeys(purchaseInfo.City);
            Map.BillingZip.SendKeys(purchaseInfo.Zip);
            Map.BillingPhone.SendKeys(purchaseInfo.Phone);
            Map.BillingEmail.SendKeys(purchaseInfo.Email);
            if (purchaseInfo.ShouldCreateAccount)
            {
                Map.CreateAccountCheckBox.Click();
            }

            if (purchaseInfo.ShouldCheckPayment)
            {
                Map.CheckPaymentsRadioButton.Click();
            }

            WaitForAjax();
            Map.PlaceOrderButton.Click();
            WaitForAjax();
        }
    }
}
