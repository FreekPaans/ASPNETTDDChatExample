using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MvcApplication9.Tests {
	[TestClass]
	public class UnitTest1 {
		private static FirefoxDriver _webDriver;		
		const string BaseUrl = "http://localhost:4539/";
		[TestInitialize]
		public void init() {
			if(_webDriver == null)  {
				_webDriver = new FirefoxDriver();		
			}			
			_webDriver.Navigate().GoToUrl(BaseUrl);			
		}

		[TestMethod]
		public void register_and_say_poo_with_different_company_name() {
			RegisterFromCompanyAndSay("freek", "microsoft", "pooa");				
		}

		[TestMethod]
		public void register_and_say_hi_with_different_company_name() {
			RegisterFromCompanyAndSay("freek", "microsoft", "hi");				
		}

		[TestMethod]
		public void register_and_say_hi() {
			RegisterFromCompanyAndSay("freek", "infi", "hi");						
		}
		
		private void RegisterFromCompanyAndSay(string name, string company, string message) {
			new RegistrationForm(_webDriver, ".registration-form")
				.EnterUsername(name)
				.EnterCompanyName(company)
				.Submit();	
			
			SubmitMessage(message);			
			Assert.AreEqual(String.Format("freek from {0} says: {1}", company, message), FindFirstMessageElement().Text);
		}

		

		private static IWebElement FindFirstMessageElement() {
			return _webDriver.FindElement(By.CssSelector(".messages .message"));
		}

		

		private static void SubmitMessage(string keys) {
			string elementName = ".enter-message";
			_webDriver.FindElement(By.CssSelector(elementName + " textarea")).SendKeys(keys);
			_webDriver.FindElement(By.CssSelector(elementName + " input[type=submit]")).Click();
		}

	
	}
}
