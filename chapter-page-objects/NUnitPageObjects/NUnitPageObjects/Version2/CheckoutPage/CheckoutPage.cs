using OpenQA.Selenium;

namespace NUnitPageObjects.Version2
{
    public partial class CheckoutPage : WebPage
    {
        public CheckoutPage(IWebDriver driver) 
            : base(driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/cart/";

        public void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            BillingFirstName.SendKeys(purchaseInfo.FirstName);
            BillingLastName.SendKeys(purchaseInfo.LastName);
            BillingCompany.SendKeys(purchaseInfo.Company);
            BillingCountryWrapper.Click();
            BillingCountryFilter.SendKeys(purchaseInfo.Country);
            GetCountryOptionByName(purchaseInfo.Country).Click();
            BillingAddress1.SendKeys(purchaseInfo.Address1);
            BillingAddress2.SendKeys(purchaseInfo.Address2);
            BillingCity.SendKeys(purchaseInfo.City);
            BillingZip.SendKeys(purchaseInfo.Zip);
            BillingPhone.SendKeys(purchaseInfo.Phone);
            BillingEmail.SendKeys(purchaseInfo.Email);
            if (purchaseInfo.ShouldCreateAccount)
            {
                CreateAccountCheckBox.Click();
            }

            if (purchaseInfo.ShouldCheckPayment)
            {
                CheckPaymentsRadioButton.Click();
            }

            WaitForAjax();
            PlaceOrderButton.Click();
            WaitForAjax();
        }
    }
}
