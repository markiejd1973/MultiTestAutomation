
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace Core
{
    public static class SeleniumUtil
    {
        public static IWebDriver? webDriver ;
        public static string outputFolder = @"..\..\..\TestOutput\";
        public static string compareFolder = @"..\..\..\TestCompare\";

    }
}
