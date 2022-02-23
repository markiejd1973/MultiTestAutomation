using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenImageSteps : StepsBase
    {
        public ThenImageSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Image ""([^""]*)"" Is Displayed")]
        public void ThenImageIsDisplayed(string imageName)
        {
            DebugOutput.Log($"First take image");
            Helpers.Image.GetImageOfElement(imageName);
        }


    }
}
