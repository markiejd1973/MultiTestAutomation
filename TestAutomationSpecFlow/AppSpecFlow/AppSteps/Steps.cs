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

namespace AppSpecFlow.AppSteps
{
    [Binding]
    public class Steps : StepsBase
    {
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

        [Then(@"SubMenu Item ""([^""]*)"" Is Not Displayed")]
        public void ThenSubMenuItemIsNotDisplayed(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
            if (element == null)
            {
                xPath = $"//a[contains(text(),'{subLinkTitle}')]";
                element = SeleniumUtil.GetElement(By.XPath(xPath),1);
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
            WhenIClickOnSubTitle("Login");
            ThenTextBoxSteps.GivenTextBoxIsDisplayed("Username");
            WhenTextBoxSteps.WhenIEnterInTextBox(userName, "Username");
            WhenTextBoxSteps.WhenIEnterInTextBox("password=1", "Password");
            ThenSteps.ThenWaitSeconds("1");
        }



        [Then(@"SubMenu Item ""([^""]*)"" Is Displayed")]
        public void ThenSubMenuItemIsDisplayed(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath), 1);
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
            if (!element.Displayed)
            {
                Assert.Fail($"Element is there - just not displayed {xPath}");
                return;
            }
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