using NUnit.Framework;

namespace NUnitPageObjects.Version3
{
    public partial class CheckoutPage
    {
        public static void AssertOrderReceived()
        {
            Assert.AreEqual(ReceivedMessage.Text, "Order received");
        }
    }
}
