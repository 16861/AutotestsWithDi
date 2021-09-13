using OpenQA.Selenium;

using SeleniumTests.Helpers;
using SeleniumTests.Driver;

namespace SeleniumTests.Pages
{
    public class GoogleFindPage : BasePage
    {
        string EditField = "//input[@title='Search']";
        string SearchButton = "//form[@role='search']/div/div/div[2]//input[@type='submit'][1]";

        public GoogleFindPage(ClientDriver driver, TestData testData) : base(driver, testData)
        {          
            base.Invoke();
        }

        public void EnterSearchedText() {
            EnterText(EditField, TestData.SearchedText);
        }

        public void ClickOnSearchButton() {
            Click(SearchButton);
        }
    }
}