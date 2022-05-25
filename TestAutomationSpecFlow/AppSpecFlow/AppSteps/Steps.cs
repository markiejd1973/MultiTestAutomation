using AppSpecFlow.Libs;
using Core;
using Core.Configuration;
using Core.Logging;
using Generic.Elements.Steps.Button;
using Generic.Elements.Steps.Page;
using Generic.Elements.Steps.TextBox;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Chrome;

namespace AppSpecFlow.AppSteps
{
    [Binding]
    public class Steps : StepsBase
    {
        public static IWebDriver? driver;
        public static WindowsDriver<WindowsElement> newDriver;

        public Steps(IStepHelpers helpers,
            GivenSteps givenSteps,
            WhenSteps whenSteps,
            ThenSteps thenSteps,

            GivenPageSteps givenPageSteps,
            WhenButtonSteps whenButtonSteps,
            WhenTextBoxSteps whenTextBoxSteps,
            ThenTextBoxSteps thenTextBoxSteps
            ) : base(helpers)
        {
            GivenSteps = givenSteps;
            WhenSteps = whenSteps;
            ThenSteps = thenSteps;

            GivenPageSteps = givenPageSteps;
            WhenButtonSteps = whenButtonSteps;
            WhenTextBoxSteps = whenTextBoxSteps;
            ThenTextBoxSteps = thenTextBoxSteps;
        }
        private GivenSteps GivenSteps { get; }
        private WhenSteps WhenSteps { get; }
        private ThenSteps ThenSteps { get; }

        private GivenPageSteps GivenPageSteps { get; }
        private WhenButtonSteps WhenButtonSteps { get; }
        private ThenTextBoxSteps ThenTextBoxSteps { get; }
        private WhenTextBoxSteps WhenTextBoxSteps { get; }

        [Given(@"Windows App ""([^""]*)"" Is Open")]
        public void GivenWindowsAppIsOpen(string applicationName)
        {
            TargetConfiguration.ReadJson(applicationName);
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, $"{TargetConfiguration.Configuration.StartUrl}");
            newDriver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), driverOptions);
            var allWindowHandles = newDriver.WindowHandles;
            newDriver.SwitchTo().Window(allWindowHandles[0]);
            SeleniumUtil.winDriver = newDriver;
        }

        [Given(@"Browser ""([^""]*)"" Is Open")]
        public void GivenBrowserIsOpen(string browserType)
        {
            if (TargetConfiguration.Configuration.Browser.ToLower() == "chrome")
            {
                driver = new ChromeDriver("c:\\chromedriver\\");
                SeleniumUtil.webDriver = driver;
                driver.Url = $"{TargetConfiguration.Configuration.StartUrl}";
            }
        }



        [Then(@"Header Is Equal To ""([^""]*)""")]
        public void ThenHeaderIsEqualTo(string headerText)
        {
            By headerLocator = By.Id("firstHeading");
            var headerElement = SeleniumUtil.GetElement(headerLocator);
            if (headerElement == null)
            {
                Assert.Fail("Failed to find header element");
                return;
            }
            var elementText = SeleniumUtil.GetElementText(headerElement);
            if (elementText == null)
            {
                Assert.Fail("Failed to Text from header element");
                return;
            }
            if (elementText != headerText)
            {
                Assert.Fail($"Failed got text {elementText} but wanted {headerText}");
                return;
            }
        }

        [When(@"I Enter ""([^""]*)"" In Document")]
        public void WhenIEnterInDocument(string text)
        {
            string proc = $"When I Enter {text} In Document";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Window.WriteInWindow("Text Editor", text)) ;
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


        [Then(@"SubMenu Item ""([^""]*)"" Is Not Displayed")]
        public void ThenSubMenuItemIsNotDisplayed(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
            if (element == null)
            {
                xPath = $"//a[contains(text(),'{subLinkTitle}')]";
                element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
                if (element == null)
                {
                    return;
                }
            }
            if (element.Displayed)
            {
                Assert.Fail($"Element is there - just not displayed {xPath}");
                return;
            }
        }


        [Given(@"I Am User ""([^""]*)""")]
        public void GivenIAmUser(string userName)
        {
            GivenPageSteps.GivenPageIsDisplayed("CGIWelcome");
            GivenPageSteps.GivenPageSizeX(1800, 1000);
            WhenButtonSteps.WhenIMouseOverButton("menu");
            if (SubMenuItemIsDisplayed("Login"))
            {
                WhenIClickOnSubTitle("Login");
                ThenTextBoxSteps.GivenTextBoxIsDisplayed("Username");
                WhenTextBoxSteps.WhenIEnterInTextBox(userName, "Username");
                WhenTextBoxSteps.WhenIEnterInTextBox("password=1", "Password");
                ThenSteps.ThenWaitSeconds("1");
            }
        }



        [Then(@"SubMenu Item ""([^""]*)"" Is Displayed")]
        public void ThenSubMenuItemIsDisplayed(string subLinkTitle)
        {
            if (!SubMenuItemIsDisplayed(subLinkTitle))
            {
                Assert.Fail($"Not displayed!");
                return;
            }

        }

        private bool SubMenuItemIsDisplayed(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
            if (element == null)
            {
                xPath = $"//a[contains(text(),'{subLinkTitle}')]";
                element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
                if (element == null)
                {
                    return false;
                }
            }
            if (!element.Displayed)
            {
                return false;
            }
            return true;

        }


        [When(@"I Click On SubMenu ""([^""]*)""")]
        [When(@"I Click On SubTitle ""([^""]*)""")]
        public void WhenIClickOnSubTitle(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath),1);
            if (element == null)
            {
                xPath = $"//a[contains(text(),'{subLinkTitle}')]";
                element = SeleniumUtil.GetElement(By.XPath(xPath));
                if (element == null)
                {
                    Assert.Fail($"Failed to find element @ {xPath}");
                    return;
                }
            }
            if (!SeleniumUtil.Click(element))
            {
                Assert.Fail($"Failed to CLICK element @ {xPath}");
                return;
            }
        }



        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            DebugOutput.Log($"GivenTheFirstNumberIs ");
        }



        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            DebugOutput.Log($"WhenTheTwoNumbersAreAdded ");
        }


        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            DebugOutput.Log($"GivenTheSecondNumberIs {p0}");
        }

    }
}