using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Autofac;

using SeleniumTests.Pages;
using SeleniumTests.Helpers;

namespace SeleniumTests.Tests
{   
    [TestFixture]
    public class Class1 : BaseTests
    {
        [Test]
        public void MainTest() {
            var googleFindPage = GetObject<GoogleFindPage>();
            googleFindPage.EnterSearchedText();
            googleFindPage.ClickOnSearchButton();

            var googleSearchResultPage = GetObject<GoogleSearchResultPage>();
            var text = googleSearchResultPage.GetTextInSerchResult();

            var expectedText = GetObject<TestData>().ExpectedText;
            System.Console.WriteLine($"text: {expectedText}");

            Assert.IsTrue(text.Contains(expectedText), $"text has not {expectedText} inside it: {text}");   
        }
    }
}
