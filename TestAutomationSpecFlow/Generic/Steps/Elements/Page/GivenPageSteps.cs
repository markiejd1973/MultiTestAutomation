using Core;
using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Page
{
    [Binding]
    public class GivenPageSteps : StepsBase
    {
        public GivenPageSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Given(@"Page ""([^""]*)"" Is Displayed")]
        public void GivenPageIsDisplayed(string pageName)
        {
            if(Helpers.Page.IsDisplayed(pageName))
            {
                DebugOutput.Log($"WORKED");
                Helpers.Page.SetCurrentPage(pageName);
                return;
            }
            Assert.Fail("failed");
        }

        [Given(@"Page Size (.*) x (.*)")]
        public void GivenPageSizeX(int widthPixels, int heightPixels)
        {
            SeleniumUtil.SetWindowSize(widthPixels, heightPixels);
        }


    }
}
