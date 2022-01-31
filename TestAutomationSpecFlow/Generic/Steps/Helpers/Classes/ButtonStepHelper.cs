using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class ButtonStepHelper : StepHelper, IButtonStepHelper
    {
        private readonly ITargetForms targetForms;
        public ButtonStepHelper(FeatureContext featureContext) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public string Hello()
        {
            CurrentPage = targetForms["login"];
            DebugOutput.Log($"Proc - GetCurrentPageName");
            var fullPage = CurrentPage.ToString();
            DebugOutput.Log($"Full Page Name = {fullPage}");
            var fixShortPageNameArray = fullPage.Split(".");
            var fixShortPageNameLength = fixShortPageNameArray.Length;
            DebugOutput.Log($"We have {fixShortPageNameLength} texts in our full page name");
            var fixShortPageName = fixShortPageNameArray[fixShortPageNameLength - 1];
            DebugOutput.Log($"Fixed short page name = {fixShortPageName}");
            var finalPage = fixShortPageName.Replace("Page", "");
            DebugOutput.Log($"RETURNING {finalPage}");
            return finalPage;
        }

    }
}
