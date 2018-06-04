using NUnit.Framework;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Firefox;

namespace seltestgooglesearch
{
    [TestFixture()]
    public class GoogleSearch
    {
        [Test()]
        public void SearchResultGreater_then_100000_Using_Firefox()
        {
			using (var driver = new FirefoxDriver())
			{
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
				driver.Manage().Window.Maximize();
				driver.Navigate().GoToUrl("http://www.google.com");
				var searchBox = driver.FindElementById("lst-ib");
				searchBox.SendKeys("kai");
				searchBox.Submit();			
				var searchResults = driver.FindElementById("resultStats");
				var result = searchResults.Text;
				string[] results = result.Split(' ');              
				Assert.Greater(results[1], "100000");
			}
        }
    }
}
