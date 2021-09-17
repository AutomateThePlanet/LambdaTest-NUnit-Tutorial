using NUnit.Framework;

namespace NUnitPageObjects.Version1.Main
{
    public class Assertions
    {
        private readonly Map _map;

        public Assertions(Map map)
        {
            _map = map;
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _map.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
