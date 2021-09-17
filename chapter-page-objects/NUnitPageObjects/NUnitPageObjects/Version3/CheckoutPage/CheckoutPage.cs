using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class CheckoutPage
    {
        public static void GoTo()
        {
            DriverFacade.GoTo("http://demos.bellatrix.solutions/cart/", () => DriverFacade.WaitAndFindElement(By.Id("billing_first_name")));
        }

        public static void FillBillingInfo(PurchaseInfo purchaseInfo)
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

            DriverFacade.WaitForAjax();
            PlaceOrderButton.Click();
            DriverFacade.WaitForAjax();
        }
    }
}
