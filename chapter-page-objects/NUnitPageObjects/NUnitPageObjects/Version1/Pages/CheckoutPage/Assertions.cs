using NUnit.Framework;

namespace NUnitPageObjects.Version1.Checkout
{
    public class Assertions
    {
        private readonly Map _map;

        public Assertions(Map map)
        {
            _map = map;
        }

        public void AssertOrderReceived()
        {
            Assert.AreEqual(_map.ReceivedMessage.Text, "Order received");
        }
    }
}
