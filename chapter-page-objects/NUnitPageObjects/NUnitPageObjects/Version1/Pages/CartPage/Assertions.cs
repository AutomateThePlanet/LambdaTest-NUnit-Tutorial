using NUnit.Framework;

namespace NUnitPageObjects.Version1.Cart
{
    public class Assertions
    {
        private readonly Map _map;

        public Assertions(Map map)
        {
            _map = map;
        }

        public void AssertCouponAppliedSuccessfully()
        {
            Assert.AreEqual("Coupon code applied successfully.", _map.MessageAlert.Text);
        }

        public void AssertTotalPrice(string expectedPrice)
        {
            Assert.AreEqual(expectedPrice, _map.TotalSpan.Text);
        }
    }
}
