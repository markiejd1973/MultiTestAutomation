
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
        public static string failedFindElement = "Failed to find element!";
        public static bool Click(IWebElement element)
        {
            DebugOutput.Log($"Sel - Click {element}");

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

        public static bool EnterText(IWebElement element, string text, string key = "")
        {
            DebugOutput.Log($"Sel - EnterText {element} {text} {key}");
            try
            {
                element.SendKeys(text);
                if (string.IsNullOrEmpty(key)) return true;
            }
            catch (Exception ex)
            {
                DebugOutput.Log($"Failed to Enter Text {element} {text} {ex}");
                return false;
            }
            return SendKey(element, key);           
        }


        public static bool MoveToElement(IWebElement element)
        {
            DebugOutput.Log($"Sel - MoveToElement {element} ");
            try
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(element);
                action.Perform();
                return true;
            }
            catch
            {
                DebugOutput.Log($"Failed to move!");
                return false;
            }
        }

        // PRIVATE

        private static bool SendKey(IWebElement element, string key)
        {
            DebugOutput.Log($"Sel - SendKey {element} {key}");
            if (string.IsNullOrEmpty(key)) return false;
            try
            {
                switch (key)
                {
                    default:
                        {
                            element.SendKeys(key);
                            return true;
                        }
                    case "clear":
                        {
                            element.SendKeys(Keys.Control + "a");
                            element.SendKeys(Keys.Delete);
                            return true;
                        }
                    case "enter":
                        {
                            element.SendKeys(Keys.Return);
                            return true;
                        }
                    case "tab":
                        {
                            element.SendKeys(Keys.Tab);
                            return true;
                        }
                }
            }
            catch
            {
                DebugOutput.Log($"problem sending key!");
                return false;
            }
        }

        public static bool IsEnabled(IWebElement element)
        {
            DebugOutput.Log($"Sel - IsEnabled {element} ");
            try
            {
                return element.Enabled;
            }
            catch (Exception ex)
            {
                DebugOutput.Log($"Had a failed returning elements Enabled flag! {ex}");
                return false;
            }
        }

        public static bool IsSelected(IWebElement element)
        {
            DebugOutput.Log($"Sel - IsSelected {element} ");
            try
            {
                DebugOutput.Log($"IT IS {element.Selected}");
                return element.Selected;
            }
            catch (Exception ex)
            {
                DebugOutput.Log($"Had a failed returning elements Selected flag! {ex}");
                return false;
            }

        }

        public static IWebElement GetElement(By locator, int timeout = 0)
        {
            DebugOutput.Log($"Sel - GetElement {locator} {timeout}");
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

        public static List<IWebElement> GetElements(By locator, int timeout = 0)
        {
            DebugOutput.Log($"Sel - GetElements (plural) {locator} {timeout}");
            var elementList = new List<IWebElement>();
            try
            {
                if (timeout < 1)
                {
                    timeout = TargetConfiguration.Configuration.PositiveTimeout;
                    DebugOutput.Log($"Using default POSITIVE TIMEOUT {timeout}");
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    var elements =  wait.Until(drv => drv.FindElements(locator));
                    foreach (var element in elements)
                    {
                        elementList.Add(element);
                    }
                    DebugOutput.Log($"We have {elementList.Count} elements found");
                    return elementList;
                }
                DebugOutput.Log($"Instant Check");
                var elementsQuick =  webDriver.FindElements(locator);
                foreach (var element in elementsQuick)
                {
                    elementList.Add(element);
                }
                DebugOutput.Log($"We have {elementList.Count} elements found");
                return elementList;
            }
            catch
            {
                DebugOutput.Log("FAILED GET ELEMENTSSSS");
                return elementList;
            }
        }

        public static string GetElementText(IWebElement element)
        {
            DebugOutput.Log($"Sel - GetElementText {element} ");
            if (element == null) return failedFindElement;
            DebugOutput.Log($"Attribute Text");
            if (!string.IsNullOrEmpty(GetElementAttributeValue(element, "text"))) return SeleniumUtil.GetElementAttributeValue(element, "text");
            DebugOutput.Log($"Attribute Value");
            if (!string.IsNullOrEmpty(GetElementAttributeValue(element, "value"))) return SeleniumUtil.GetElementAttributeValue(element, "value");
            DebugOutput.Log($"Failed to get any text from {element}"); 
            DebugOutput.Log($"Attribute textContent");
            if (!string.IsNullOrEmpty(GetElementAttributeValue(element, "textContent"))) return SeleniumUtil.GetElementAttributeValue(element, "textContent");
            return "";
        }

        public static string GetElementAttributeValue(IWebElement element, string attribute)
        {
            DebugOutput.Log($"Sel - GetElementAttributeValue {element} {attribute}");

            if (string.IsNullOrEmpty(attribute)) return "";
            try
            {
                DebugOutput.Log($"attribute {attribute} = {element.GetAttribute(attribute)}");
                return element.GetAttribute(attribute);
            }
            catch
            {
                DebugOutput.Log($"Failed to read attribute {attribute}");
                return "";
            }
        }

        public static IWebElement GetElementUnderElement(IWebElement parentElement, By locator, int timeout = 0)
        {
            DebugOutput.Log($"Sel - GetElementUnderElement {parentElement} {locator} {timeout}");
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
                DebugOutput.Log(failedFindElement);
                return null;
            }
        }

    }
}
