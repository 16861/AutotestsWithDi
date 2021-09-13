using OpenQA.Selenium;

using SeleniumTests.Helpers;
using SeleniumTests.Driver;

namespace SeleniumTests.Pages
{
    public class GoogleSearchResultPage : BasePage
    {
        string SearchResults = "//div[@id='search']/div/div/div[@class='g']//a/h3";

        public GoogleSearchResultPage(ClientDriver driver, TestData testData) : base(driver, testData)
        {
        }

        public string GetTextInSerchResult() {
            return GetElementsText(SearchResults)[TestData.RowNumber].Text;
        }
    }
}