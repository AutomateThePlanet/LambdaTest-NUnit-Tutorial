using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitPageObjects
{
    public class ProductPurchaseTests : IDisposable
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _webDriverWait;

        public ProductPurchaseTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Test]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            AddRocketToShoppingCart();

            ApplyCoupon();

            IncreaseProductQuantity();

            var proceedToCheckout = WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();
            WaitUntilPageLoadsCompletely();

            var billingFirstName = WaitAndFindElement(By.Id("billing_first_name"));
            billingFirstName.SendKeys("Anton");
            var billingLastName = WaitAndFindElement(By.Id("billing_last_name"));
            billingLastName.SendKeys("Angelov");
            var billingCompany = WaitAndFindElement(By.Id("billing_company"));
            billingCompany.SendKeys("Space Flowers");
            var billingCountryWrapper = WaitAndFindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = WaitAndFindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.SendKeys("Germany");

            var germanyOption = WaitAndFindElement(By.XPath("//*[contains(text(),'Germany')]"));
            germanyOption.Click();

            var billingAddress1 = WaitAndFindElement(By.Id("billing_address_1"));
            billingAddress1.SendKeys("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = WaitAndFindElement(By.Id("billing_address_2"));
            billingAddress2.SendKeys("Lützowplatz 17");
            var billingCity = WaitAndFindElement(By.Id("billing_city"));
            billingCity.SendKeys("Berlin");
            var billingZip = WaitAndFindElement(By.Id("billing_postcode"));
            billingZip.Clear();
            billingZip.SendKeys("10115");
            var billingPhone = WaitAndFindElement(By.Id("billing_phone"));
            billingPhone.SendKeys("+00498888999281");
            var billingEmail = WaitAndFindElement(By.Id("billing_email"));
            billingEmail.SendKeys("info@berlinspaceflowers.com");

            WaitForAjax();

            var placeOrderButton = WaitAndFindElement(By.Id("place_order"));
            placeOrderButton.Click();

            WaitForAjax();

            var receivedMessage = WaitAndFindElement(By.XPath("//h1[text() = 'Order received']"));
            Assert.AreEqual("Order received", receivedMessage.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            quantityBox.SendKeys("2");

            WaitForAjax();

            WaitToBeClickable(By.CssSelector("[value*='Update cart']"));
            var updateCart = WaitAndFindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();

            WaitForAjax();

            var totalSpan = WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = WaitAndFindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");

            var applyCouponButton = WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();

            WaitForAjax();

            var messageAlert = WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void AddRocketToShoppingCart()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var addToCartFalcon9 = WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            var viewCartButton = WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        private IWebElement WaitAndFindElement(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            return webDriverWait.Until(ExpectedConditions.ElementExists(by));
        }

        private void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)_driver;
            _webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        private void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)_driver;
            _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
