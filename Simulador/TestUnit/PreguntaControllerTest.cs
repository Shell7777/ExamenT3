using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Simulador.TestUnit
{
    [TestFixture]
    class PreguntaControllerTest
    {
        IWebDriver chrome = new ChromeDriver();
        [Test]
        public void Buscar()
        {
            chrome.Url = "http://localhost:58972/Usuario/Login";
            var button = chrome.FindElement(By.CssSelector("#btn"));
            button.Click();
            button = chrome.FindElement(By.CssSelector("#temaLink"));
            button.Click();
            var input = chrome.FindElement(By.CssSelector("#val"));
            input.SendKeys("JEJEJE");
            button = chrome.FindElement(By.CssSelector("#search"));
            button.Click();
            Thread.Sleep(3000);
            chrome.Close();
        }
        [Test]
        public void Eliminar()
        {
            chrome.Url = "http://localhost:58972/Usuario/Login";
            var button = chrome.FindElement(By.CssSelector("#btn"));
            button.Click();
            button = chrome.FindElement(By.CssSelector("#temaLink"));
            button.Click();
            var eliminar = chrome.FindElements(By.CssSelector("a"));
            eliminar[7].Click();
            chrome.Close();
        }
        [Test]
        public void Editar()
        {
            chrome.Url = "http://localhost:58972/Usuario/Login";
            var button = chrome.FindElement(By.CssSelector("#btn"));
            button.Click();
            button = chrome.FindElement(By.CssSelector("#temaLink"));
            button.Click();
            var eliminar = chrome.FindElements(By.CssSelector("a"));
            eliminar[6].Click();
        var input1 = chrome.FindElement(By.CssSelector("#name"));
            input1.SendKeys("La casa de papel");
            var input = chrome.FindElement(By.CssSelector("textarea"));
            input.SendKeys("La casa de papel");
            button = chrome.FindElement(By.CssSelector("#btn"));
            button.Click();
            chrome.Close();
        }
    }
} 
