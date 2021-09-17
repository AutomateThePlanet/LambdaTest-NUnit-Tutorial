using NUnit.Framework;

namespace NUnitPageObjects.Version3
{
    public partial class CartPage
    {
        public static void AssertCouponAppliedSuccessfully()
        {
            Assert.AreEqual("Coupon code applied successfully.", MessageAlert.Text);
        }

        public static void AssertTotalPrice(string expectedPrice)
        {
            Assert.AreEqual(expectedPrice, TotalSpan.Text);
        }
    }
}
