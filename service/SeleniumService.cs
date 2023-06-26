using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using NSoup.Nodes;

namespace Csindex.WebCrawlers
{
    internal class SeleniumService
    {
        private IWebDriver _webDriver;

        public SeleniumService()
        {
        }

        public void SetUpChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        public void QuiteDriver()
        {
            _webDriver.Quit();
        }
        /**
         * 根据URL获取HTML页面
         */
        public Document GetHtmlPageByUrl(String url)
        {
            this.SetUpChromeDriver();
            try
            {
                _webDriver.Navigate().GoToUrl(url);
                // 获取页面标题
                String title = _webDriver.Title;
                Console.WriteLine(title);
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(8000);
                String pageSource = _webDriver.PageSource;
                if (String.IsNullOrEmpty(pageSource))
                {
                    return null;
                }
                return NSoup.NSoupClient.Parse(pageSource);
            }
            catch (Exception e)
            {
                Console.WriteLine($"获取Html页面失败！: '{e}'");
                return null;
            }
            finally
            {
                this.QuiteDriver();
            }
        }
    }
}
