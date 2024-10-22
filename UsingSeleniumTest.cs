using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace MyFirstCSharpApp.GettingStarted
{
    [TestClass]
    public class UsingSeleniumTest
    {

        [TestMethod]
        public void EightComponents()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var title = driver.Title;
            Assert.AreEqual("Web form", title);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var textBox = driver.FindElement(By.Name("my-text"));
            var passwordBox = driver.FindElement(By.Name("my-password"));
            var textAreaBox = driver.FindElement(By.Name("my-textarea"));
            var dropDown = driver.FindElement(By.Name("my-select"));
            var searchInput = driver.FindElement(By.Name("my-datalist"));
            IWebElement fileInput = driver.FindElement(By.Name("my-file"));
            var checkBox1 = driver.FindElement(By.Id("my-check-1"));
            var checkBox2 = driver.FindElement(By.Id("my-check-2"));
            var dateInput = driver.FindElement(By.Name("my-date"));

            if (!checkBox2.Selected)
            {
             checkBox2.Click();   
            }
            if (checkBox1.Selected)
            {
                checkBox1.Click();
            }

            dateInput.SendKeys("2024-10-22");

            string filePath = @"/Users/josephmwanzia/Downloads/RESUME.pdf";


            SelectElement selectElement = new SelectElement(dropDown);
            searchInput.SendKeys("New York");
            fileInput.SendKeys(filePath);
            selectElement.SelectByText("One");
            var submitButton = driver.FindElement(By.TagName("button"));
            

            textBox.SendKeys("Selenium");
            passwordBox.SendKeys("SeleniumPassword");
            textAreaBox.SendKeys("my-textarea");
            submitButton.Click();
            
            var message = driver.FindElement(By.Id("message"));
            var value = message.Text;
            Assert.AreEqual("Received!", value);
            
            // driver.Quit();
        }
    }
}