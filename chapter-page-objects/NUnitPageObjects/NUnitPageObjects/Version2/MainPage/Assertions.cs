using NUnit.Framework;

namespace NUnitPageObjects.Version2
{
    public partial class MainPage
    {
        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
