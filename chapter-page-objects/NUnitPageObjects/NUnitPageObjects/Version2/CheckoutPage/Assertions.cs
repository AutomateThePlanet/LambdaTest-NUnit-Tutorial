using NUnit.Framework;

namespace NUnitPageObjects.Version2
{
    public partial class CheckoutPage
    {
        public void AssertOrderReceived()
        {
            Assert.AreEqual(ReceivedMessage.Text, "Order received");
        }
    }
}
