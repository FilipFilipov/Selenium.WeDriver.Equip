﻿using System;
using OpenQA.Selenium.Support.UI;

namespace OpenQA.Selenium
{
    public static class ExpectedConditionsExtention
    {
        /// <summary>
        /// An expectation for checking that an elements text.
        /// </summary>
        /// <param name="locator">The <see cref="By"/> locator of the <see cref="IWebElement"/></param>
        /// <param name="text">The text an <see cref="IWebElement"/> should be</param>
        /// <returns><see langword="true"/> if the <see cref="IWebElement">IWebElements</see> text equals; otherwise, <see langword="false"/></returns>
        public static Func<IWebDriver, bool> ElementTextEquals(this ExpectedConditions expectedConditions, By locator, string text)
        {
            return (driver) => { return driver.FindElement(locator).Text == text; };
        }

        /// <summary>
        /// An expectation for checking that an element contains specific text.
        /// </summary>
        /// <param name="locator">The <see cref="By"/> locator of the <see cref="IWebElement"/></param>
        /// <param name="text">The text an <see cref="IWebElement"/> should contain</param>
        /// <returns><see langword="true"/> if the <see cref="IWebElement"/> contains the text; otherwise, <see langword="false"/></returns>
        public static Func<IWebDriver, bool> ElementTextContains(this ExpectedConditions expectedConditions, By locator, string text)
        {
            return (driver) => { return driver.FindElement(locator).Text.Contains(text); };
        }

        /// <summary>
        /// An expectation for checking that an element is not present on the DOM of a page and not visible
        /// </summary>
        /// <param name="locator">The <see cref="By"/> locator of the <see cref="IWebElement"/></param>
        /// <returns><see langword="true"/> if the <see cref="IWebElement"/> is not present; otherwise, <see langword="false"/></returns>
        public static Func<IWebDriver, bool> ElementNotVisible(this ExpectedConditions expectedConditions, By locator)
        {
            return (driver) =>
            {
                try
                {
                    return null != ElementIfVisible(driver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (element.Displayed)
            {
                return element;
            }
            else
            {
                return null;
            }
        }
    }
}
