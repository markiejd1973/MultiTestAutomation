
using Core.Configuration;
using Core.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Core
{
    public static class SeleniumUtil
    {
        public static IWebDriver? webDriver ;
        public static string outputFolder = @"..\..\..\TestOutput\";
        public static string compareFolder = @"..\..\..\TestCompare\";

        public static IWebElement GetElement(By locator, int timeout = 0)
        {
            try
            {
                if (timeout < 1)
                {
                    timeout = TargetConfiguration.Configuration.PositiveTimeout;
                    DebugOutput.Log($"Using default POSITIVE TIMEOUT {timeout}");
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(drv => drv.FindElement(locator));
                }
                DebugOutput.Log($"Using zero timeout");
                return webDriver.FindElement(locator);
            }
            catch
            {
                DebugOutput.Log("FAILED GET ELEMENT");
                return null;
            }
        }

        public static IWebElement GetElementUnderElement(IWebElement parentElement, By locator, int timeout = 0)
        {
            try
            {
                if (timeout < 1)
                {
                    timeout = TargetConfiguration.Configuration.PositiveTimeout;
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(driv => parentElement.FindElement(locator));
                }
                DebugOutput.Log($"Using zero timeout");
                return parentElement.FindElement(locator);
            }
            catch
            {
                DebugOutput.Log("FAILED GET ELEMENT");
                return null;
            }
        }

    }
}
