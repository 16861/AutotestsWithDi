using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

using SeleniumTests.Helpers;

namespace SeleniumTests.Pages
{
    public abstract class BasePage
    {
        IWebDriver ClientDriver;
        protected TestData TestData;
        public BasePage(IWebDriver driver, TestData testData)
        {
            ClientDriver = driver;
            TestData = testData;
        }

        protected void Invoke() {
            if (!Exists())
                ClientDriver.Navigate().GoToUrl(TestData.Url);
        }

        protected bool Exists() {
            if(ClientDriver.Url != TestData.Url)
                return false;
            return true;
        }

        protected void Click(string xpath) {
            WaitForVisible(xpath);
            ClientDriver.FindElement(By.XPath(xpath)).Click();
        }

        protected void EnterText(string xpath, string text) {
            WaitForVisible(xpath);
            ClientDriver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        protected void WaitForVisible(string xpath) {
            var wait = new WebDriverWait(ClientDriver, TimeSpan.FromSeconds(30));
            wait.Until(condition => {
                try
                {
                    var elementToBeDisplayed = ClientDriver.FindElement(By.XPath(xpath));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }});
        }

        protected ReadOnlyCollection<IWebElement> GetElementsText(string xpath) {
            WaitForVisible(xpath);
            return ClientDriver.FindElements(By.XPath(xpath));
        }
    }
}