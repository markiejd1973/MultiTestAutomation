using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenTreeSteps : StepsBase
    {
        public WhenTreeSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Toggle Tree ""([^""]*)"" Node ""([^""]*)""")]
        public void WhenIToggleTreeNode(string treeName, string nodeName)
        {
            string proc = $"When I Toggle Tree {treeName} Node {nodeName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.NodeToggle(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Click Tree ""([^""]*)"" Node ""([^""]*)"" CheckBox")]
        public void WhenIClickTreeNodeCheckBox(string treeName, string nodeName)
        {
            string proc = $"When I Click Tree {treeName} Node {nodeName} CheckBox";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.ClickCheckBox(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Click Expand All Tree ""([^""]*)""")]
        public void WhenIClickExpandAllTree(string treeName)
        {
            string proc = $"When I Click Expand All Tree {treeName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.ExpandAll(treeName, true))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Click Collapse All Tree ""([^""]*)""")]
        public void WhenIClickCollapseAllTree(string treeName)
        {
            string proc = $"When I Click Expand All Tree {treeName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.ExpandAll(treeName, false))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }



    }
}
