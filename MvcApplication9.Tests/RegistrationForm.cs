using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication9.Tests {
	class RegistrationForm {
		private OpenQA.Selenium.Firefox.FirefoxDriver _webDriver;
		private string _formSelector;

		public RegistrationForm(OpenQA.Selenium.Firefox.FirefoxDriver webDriver,string formSelector) {
			_webDriver = webDriver;
			_formSelector = formSelector;
		}

		internal RegistrationForm EnterUsername(string username) {
			FindInputElementInRegistrationFormAndSendKeys("username", username);
			return this;
		}

		internal RegistrationForm EnterCompanyName(string companyName) {
			FindInputElementInRegistrationFormAndSendKeys("companyname", companyName);
			return this;

		}

		internal void Submit() {
			_webDriver.FindElement(By.CssSelector(".register-form input[type=submit]")).Click();
		}

		private void FindInputElementInRegistrationFormAndSendKeys(String inputName, String keys) {
			_webDriver
				.FindElement(By.CssSelector(string.Format(".register-form input[name={0}]", inputName)))
				.SendKeys(keys);
		}
	}
}
