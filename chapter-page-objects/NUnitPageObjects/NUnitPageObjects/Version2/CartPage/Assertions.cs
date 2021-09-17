using NUnit.Framework;

namespace NUnitPageObjects.Version2
{
    public partial class CartPage
    {
        public void AssertCouponAppliedSuccessfully()
        {
            Assert.AreEqual("Coupon code applied successfully.", MessageAlert.Text);
        }

        public void AssertTotalPrice(string expectedPrice)
        {
            Assert.AreEqual(expectedPrice, TotalSpan.Text);
        }
    }
}
