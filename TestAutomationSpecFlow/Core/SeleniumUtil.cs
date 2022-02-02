
using Core.Configuration;
using Core.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Core
{
    public static class SeleniumUtil
    {
        public static IWebDriver? webDriver ;
        public static string outputFolder = @"..\..\..\TestOutput\";
        public static string compareFolder = @"..\..\..\TestCompare\";

        public static bool Click(IWebElement element)
        {
            DebugOutput.Log($"Click {element}");

            try
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(element);
                action.Click();
                action.Build();
                action.Perform();
                return true;
            }
            catch (Exception ex)
            {
                DebugOutput.Log($"Failed to click {element} {ex}");
                return false;   
            }
        }

        public static IWebElement GetElement(By locator, int timeout = 0)
        {
            DebugOutput.Log($"GetElement {locator} {timeout}");
            try
            {
                if (timeout < 1)
                {
                    timeout = TargetConfiguration.Configuration.PositiveTimeout;
                    DebugOutput.Log($"Using default POSITIVE TIMEOUT {timeout}");
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(drv => drv.FindElement(locator));
                }
                DebugOutput.Log($"Instant Check");
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
            DebugOutput.Log($"GetElementUnderElement {parentElement} {locator} {timeout}");
            try
            {
                if (timeout < 1)
                {
                    timeout = TargetConfiguration.Configuration.PositiveTimeout;
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(driv => parentElement.FindElement(locator));
                }
                DebugOutput.Log($"Instant Check");
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
