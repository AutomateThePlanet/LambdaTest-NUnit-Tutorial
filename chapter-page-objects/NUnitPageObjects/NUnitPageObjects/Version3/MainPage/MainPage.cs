using NUnitPageObjects.Version1.Main;
using OpenQA.Selenium;

namespace NUnitPageObjects.Version3
{
    public static partial class MainPage
    {
        public static void GoTo()
        {
            DriverFacade.GoTo("http://demos.bellatrix.solutions/", () => DriverFacade.WaitAndFindElement(By.CssSelector("[data-product_id*='28']")));
        }

        public static void AddRocketToShoppingCart(string rocketName)
        {
            GoTo();
            GetProductBoxByName(rocketName).Click();
            ViewCartButton.Click();
        }
    }
}
