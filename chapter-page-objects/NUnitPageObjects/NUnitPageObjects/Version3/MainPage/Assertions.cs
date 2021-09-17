using NUnit.Framework;

namespace NUnitPageObjects.Version3
{
    public partial class MainPage
    {
        public static void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
