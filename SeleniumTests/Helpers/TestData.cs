namespace SeleniumTests.Helpers
{
    public class TestData
    {
        public string Url { get {return "https://www.google.com.ua";}}
        public int RowNumber { get {return 4;}}
        public string SearchedText { get {return "Selenium IDE";}}
        public string ExpectedText { get {return "Selenium";}}
    }
}