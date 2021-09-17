using OpenQA.Selenium;

namespace NUnitPageObjects.Version2
{
    public partial class CheckoutPage
    {
        public IWebElement BillingFirstName => WaitAndFindElement(By.Id("billing_first_name"));
        public IWebElement BillingLastName => WaitAndFindElement(By.Id("billing_last_name"));
        public IWebElement BillingCompany => WaitAndFindElement(By.Id("billing_company"));
        public IWebElement BillingCountryWrapper => WaitAndFindElement(By.Id("select2-billing_country-container"));
        public IWebElement BillingCountryFilter => WaitAndFindElement(By.ClassName("select2-search__field"));
        public IWebElement BillingAddress1 => WaitAndFindElement(By.Id("billing_address_1"));
        public IWebElement BillingAddress2 => WaitAndFindElement(By.Id("billing_address_2"));
        public IWebElement BillingCity => WaitAndFindElement(By.Id("billing_city"));
        public IWebElement BillingZip => WaitAndFindElement(By.Id("billing_postcode"));
        public IWebElement BillingPhone => WaitAndFindElement(By.Id("billing_phone"));
        public IWebElement BillingEmail => WaitAndFindElement(By.Id("billing_email"));
        public IWebElement CreateAccountCheckBox => WaitAndFindElement(By.Id("createaccount"));
        public IWebElement CheckPaymentsRadioButton => WaitAndFindElement(By.CssSelector("[for*='payment_method_cheque']"));
        public IWebElement PlaceOrderButton => WaitAndFindElement(By.Id("place_order"));
        public IWebElement ReceivedMessage => WaitAndFindElement(By.XPath("//h1"));

        public IWebElement GetCountryOptionByName(string countryName)
        {
            return WaitAndFindElement(By.XPath($"//*[contains(text(),'{countryName}')]"));
        }
    }
}
