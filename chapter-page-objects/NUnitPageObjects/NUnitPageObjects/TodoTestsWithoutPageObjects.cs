using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitPageObjects
{
    public class TodoTestsWithoutPageObjects : IDisposable
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _webDriverWait;
        private readonly Actions _actions;

        public TodoTestsWithoutPageObjects()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
            _actions = new Actions(_driver);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [TestCase("Backbone.js")]
        [TestCase("AngularJS")]
        [TestCase("React")]
        [TestCase("Vue.js")]
        [TestCase("CanJS")]
        [TestCase("Ember.js")]
        [TestCase("KnockoutJS")]
        [TestCase("Polymer")]
        [TestCase("Angular 2.0")]
        [TestCase("Dart")]
        [TestCase("Elm")]
        [TestCase("Closure")]
        [TestCase("Vanilla JS")]
        [TestCase("jQuery")]
        [TestCase("cujoJS")]
        [TestCase("Spine")]
        [TestCase("Dojo")]
        [TestCase("Mithril")]
        [TestCase("Kotlin + React")]
        [TestCase("Firebase + AngularJS")]
        [TestCase("Vanilla ES6")]
        public void VerifyTodoListCreatedSuccessfully(string technology)
        {
            _driver.Navigate().GoToUrl("https://todomvc.com/");
            OpenTechnologyApp(technology);
            AddNewToDoItem("Clean the car");
            AddNewToDoItem("Clean the house");
            AddNewToDoItem("Buy Ketchup");
            GetItemCheckBox("Buy Ketchup").Click();
            AssertLeftItems(2);
        }

        private void AssertLeftItems(int expectedCount)
        {
            var resultSpan = WaitAndFindElement(By.XPath("//footer/span"));
            if (expectedCount <= 0)
            {
                ValidateInnerTextIs(resultSpan, $"{expectedCount} item left");
            }
            else
            {
                ValidateInnerTextIs(resultSpan, $"{expectedCount} items left");
            }
        }

        private void ValidateInnerTextIs(IWebElement resultSpan, string expectedText)
        {
            _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
        }

        private IWebElement GetItemCheckBox(string todoItem)
        {
            return WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
        }

        private void AddNewToDoItem(string todoItem)
        {
            var todoInput = WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            todoInput.SendKeys(todoItem);
            _actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
        }

        private void OpenTechnologyApp(string name)
        {
            var technologyLink = WaitAndFindElement(By.LinkText(name));
            technologyLink.Click();
        }

        private IWebElement WaitAndFindElement(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
