using AppSpecFlow.Libs;
using Core;
using Core.Configuration;
using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;

namespace AppSpecFlow.AppSteps
{
    [Binding]
    public class Steps : StepsBase
    {
        public Steps(IStepHelpers helpers
            ) : base(helpers)
        {
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

        [When(@"I Click On SubTitle ""([^""]*)""")]
        public void WhenIClickOnSubTitle(string subLinkTitle)
        {
            var xPath = $"//a[@title='{subLinkTitle}']";
            var element = SeleniumUtil.GetElement(By.XPath(xPath));
            if (element == null)
            {
                Assert.Fail($"Failed to find element @ {xPath}");
                return;
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