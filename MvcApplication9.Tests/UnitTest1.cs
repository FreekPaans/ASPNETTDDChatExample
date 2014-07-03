using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Collections.Generic;

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
		public void two_messages()
		{
			RegisterFromCompany("freek", "microsoft");
			
			SubmitMessage("hello");
			SubmitMessage("goodbye");

			AssertMessageVisible("freek","microsoft", "hello");
			AssertMessageVisible("freek","microsoft", "goodbye");
		}
		
		[TestMethod]
		public void register_and_say_poo_with_different_company_name() {
			RegisterFromCompanyAndSayAndVerifyMessageVisible("freek", "microsoft", "pooa");				
		}

		[TestMethod]
		public void register_and_say_hi_with_different_company_name() {
			RegisterFromCompanyAndSayAndVerifyMessageVisible("freek", "microsoft", "hi");				
		}

		[TestMethod]
		public void register_and_say_hi() {
			RegisterFromCompanyAndSayAndVerifyMessageVisible("freek", "infi", "hi");						
		}
		
		private void RegisterFromCompanyAndSayAndVerifyMessageVisible(string username, string company, string message) {
			RegisterFromCompany(username,company);
			
			SubmitMessage(message);
			AssertMessageVisible(username,company,message);
		}

		private static void AssertMessageVisible(string username, string company,string message) {
			var expectedMessage = String.Format("{2} from {0} says: {1}",company,message,username);
			foreach(var element in FindMessageElements()) {
				if(element.Text == expectedMessage) {
					return;
				}
			}

			Assert.Fail(string.Format("Message with text '{0}' not found", expectedMessage));
		}

		private static void RegisterFromCompany(string name,string company) {
			new RegistrationForm(_webDriver,".registration-form")
						 .EnterUsername(name)
						 .EnterCompanyName(company)
						 .Submit();
		}

		

		private static ICollection<IWebElement> FindMessageElements() {
			return _webDriver.FindElements(By.CssSelector(".messages .message"));
		}

		

		private static void SubmitMessage(string keys) {
			string elementName = ".enter-message";
			_webDriver.FindElement(By.CssSelector(elementName + " textarea")).SendKeys(keys);
			_webDriver.FindElement(By.CssSelector(elementName + " input[type=submit]")).Click();
		}

	
	}
}
