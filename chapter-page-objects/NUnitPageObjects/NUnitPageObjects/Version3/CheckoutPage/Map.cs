using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public partial class CheckoutPage
    {
        public static IWebElement BillingFirstName => DriverFacade.WaitAndFindElement(By.Id("billing_first_name"));
        public static IWebElement BillingLastName => DriverFacade.WaitAndFindElement(By.Id("billing_last_name"));
        public static IWebElement BillingCompany => DriverFacade.WaitAndFindElement(By.Id("billing_company"));
        public static IWebElement BillingCountryWrapper => DriverFacade.WaitAndFindElement(By.Id("select2-billing_country-container"));
        public static IWebElement BillingCountryFilter => DriverFacade.WaitAndFindElement(By.ClassName("select2-search__field"));
        public static IWebElement BillingAddress1 => DriverFacade.WaitAndFindElement(By.Id("billing_address_1"));
        public static IWebElement BillingAddress2 => DriverFacade.WaitAndFindElement(By.Id("billing_address_2"));
        public static IWebElement BillingCity => DriverFacade.WaitAndFindElement(By.Id("billing_city"));
        public static IWebElement BillingZip => DriverFacade.WaitAndFindElement(By.Id("billing_postcode"));
        public static IWebElement BillingPhone => DriverFacade.WaitAndFindElement(By.Id("billing_phone"));
        public static IWebElement BillingEmail => DriverFacade.WaitAndFindElement(By.Id("billing_email"));
        public static IWebElement CreateAccountCheckBox => DriverFacade.WaitAndFindElement(By.Id("createaccount"));
        public static IWebElement CheckPaymentsRadioButton => DriverFacade.WaitAndFindElement(By.CssSelector("[for*='payment_method_cheque']"));
        public static IWebElement PlaceOrderButton => DriverFacade.WaitAndFindElement(By.Id("place_order"));
        public static IWebElement ReceivedMessage => DriverFacade.WaitAndFindElement(By.XPath("//h1"));

        public static IWebElement GetCountryOptionByName(string countryName)
        {
            return DriverFacade.WaitAndFindElement(By.XPath($"//*[contains(text(),'{countryName}')]"));
        }
    }
}
