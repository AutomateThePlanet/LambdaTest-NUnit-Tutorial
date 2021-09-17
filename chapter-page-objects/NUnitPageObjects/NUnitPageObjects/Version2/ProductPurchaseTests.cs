using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitPageObjects.Version2
{
    public class ProductPurchaseTests : IDisposable
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;

        public ProductPurchaseTests()
        {
            ////string userName = Environment.GetEnvironmentVariable("LT_USERNAME", EnvironmentVariableTarget.Machine);
            ////string accessKey = Environment.GetEnvironmentVariable("LT_ACCESSKEY", EnvironmentVariableTarget.Machine);
            ////var options = new ChromeOptions();
            ////options.BrowserVersion = "91.0";
            ////options.AddAdditionalCapability("user", userName, true);
            ////options.AddAdditionalCapability("accessKey", accessKey, true);
            ////options.AddAdditionalCapability("build", "FirstSeleniumTestsInCloud", true);
            ////options.AddAdditionalCapability("name", "AddNewBirthDayItem", true);
            ////options.PlatformName = "Windows 10";

            ////options.AddAdditionalCapability("selenium_version", "3.13.0", true);
            ////options.AddAdditionalCapability("console", true, true);
            ////options.AddAdditionalCapability("network", true, true);
            ////options.AddAdditionalCapability("timezone", "UTC+03:00", true);


            ////_driver = new RemoteWebDriver(new Uri($"https://{userName}:{accessKey}@hub.lambdatest.com/wd/hub"), options);

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Test]
        public void PurchaseFalcon9()
        {
            _mainPage.GoTo();
            _mainPage.AddRocketToShoppingCart("Falcon 9");
            _cartPage.ApplyCoupon("happybirthday");
            _cartPage.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(2);
            _cartPage.AssertTotalPrice("114.00€");
            _cartPage.ProceedToCheckout();

            var purchaseInfo = new PurchaseInfo()
                               {
                                   Email = "info@berlinspaceflowers.com",
                                   FirstName = "Anton",
                                   LastName = "Angelov",
                                   Company = "Space Flowers",
                                   Country = "Germany",
                                   Address1 = "1 Willi Brandt Avenue Tiergarten",
                                   Address2 = "Lützowplatz 17",
                                   City = "Berlin",
                                   Zip = "10115",
                                   Phone = "+00498888999281",
                               };
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.AssertOrderReceived();
        }
    }
}
