using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Driver
{
    public class ClientDriver : ChromeDriver
    {
        public new void Dispose() {
            base.Close();
            base.Quit();
        }
    }
}