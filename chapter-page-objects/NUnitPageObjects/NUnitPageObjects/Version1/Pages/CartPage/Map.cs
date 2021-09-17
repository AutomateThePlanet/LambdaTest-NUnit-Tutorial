﻿using NUnitPageObjects.Version1.Pages;
using OpenQA.Selenium;

namespace NUnitPageObjects.Version1.Cart
{
    public class Map : BaseMap
    {
        public Map(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement CouponCodeTextField => WaitAndFindElement(By.Id("coupon_code"));
        public IWebElement ApplyCouponButton => WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
        public IWebElement QuantityBox => WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
        public IWebElement UpdateCart => WaitAndFindElement(By.CssSelector("[value*='Update cart']"));
        public IWebElement MessageAlert => WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
        public IWebElement TotalSpan => WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
        public IWebElement ProceedToCheckout => WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
    }
}
