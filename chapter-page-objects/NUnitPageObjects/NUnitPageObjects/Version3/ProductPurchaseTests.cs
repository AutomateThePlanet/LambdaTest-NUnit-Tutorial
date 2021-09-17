using System;
using NUnit.Framework;

namespace NUnitPageObjects.Version3
{
    public class ProductPurchaseTests : IDisposable
    {
        public ProductPurchaseTests()
        {
            DriverFacade.Start(BrowserType.Chrome);
        }

        public void Dispose()
        {
            DriverFacade.Quit();
        }

        [Test]
        public void PurchaseFalcon9()
        {
            MainPage.GoTo();
            MainPage.AddRocketToShoppingCart("Falcon 9");
            CartPage.ApplyCoupon("happybirthday");
            CartPage.AssertCouponAppliedSuccessfully();
            CartPage.IncreaseProductQuantity(2);
            CartPage.AssertTotalPrice("114.00€");
            CartPage.ProceedToCheckout();

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
            CheckoutPage.FillBillingInfo(purchaseInfo);
            CheckoutPage.AssertOrderReceived();
        }
    }
}
