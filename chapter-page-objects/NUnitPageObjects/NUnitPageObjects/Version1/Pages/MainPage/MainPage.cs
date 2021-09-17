// Copyright 2021 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using NUnitPageObjects.Version1.Main;
using OpenQA.Selenium;

namespace NUnitPageObjects.Version1
{
    public class MainPage : WebPage
    {
        public MainPage(IWebDriver driver) 
            : base(driver)
        {
            Map = new Map(driver);
            Assertions = new Assertions(Map);
        }

        public Map Map { get; }
        public Assertions Assertions { get; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart(string rocketName)
        {
            GoTo();
            Map.GetProductBoxByName(rocketName).Click();
            Map.ViewCartButton.Click();
        }

        protected override void WaitForPageToLoad()
        {
            WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
        }
    }
}
