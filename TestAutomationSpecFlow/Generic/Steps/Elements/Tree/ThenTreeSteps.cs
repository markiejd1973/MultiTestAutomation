using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenTreeSteps : StepsBase
    {
        public ThenTreeSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Tree ""([^""]*)"" Is Displayed")]
        public void ThenTreeIsDisplayed(string treeName)
        {
            string proc = $"Then Tree {treeName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsDisplayed(treeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Displays Node ""([^""]*)""")]
        public void ThenTreeDisplaysNode(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Top Node Is Equal To {nodeName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsNodeDisplayed(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


        [Then(@"Tree ""([^""]*)"" Top Node Is Equal To ""([^""]*)""")]
        public void ThenTreeTopNodeIsEqualTo(string treeName, string value)
        {
            string proc = $"Then Tree {treeName} Top Node Is Equal To {value}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.GetTopTreeNodeName(treeName) == value)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Has (.*) Nodes Displayed")]
        public void ThenTreeHasNodesDisplayed(string treeName, int numberOfNodesDisplayed)
        {
            string proc = $"Then Tree {treeName} Has {numberOfNodesDisplayed} Nodes Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.GetNumberOfNodesDisplayed(treeName) == numberOfNodesDisplayed)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" Is Expanded")]
        public void ThenTreeNodeIsExpanded(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Node {nodeName} Is Expanded";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsTreeExpandedAtNode(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" Is Contracted")]
        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" Is Not Expanded")]
        public void ThenTreeNodeIsNotExpanded(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Node {nodeName} Is Not Expanded";
            if (CombinedSteps.OuputProc(proc))
            {
                if (!Helpers.Tree.IsTreeExpandedAtNode(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" CheckBox Is Ticked")]
        public void ThenTreeNodeCheckBoxIsTicked(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Node {nodeName} CheckBox Is Ticked";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsTreeNodeTicked(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" CheckBox Is Half Ticked")]
        public void ThenTreeNodeCheckBoxIsHalfTicked(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Node {nodeName} CheckBox Is Ticked";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsTreeNodeHalfTicked(treeName, nodeName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Tree ""([^""]*)"" Node ""([^""]*)"" CheckBox Is Not Ticked")]
        public void ThenTreeNodeCheckBoxIsNotTicked(string treeName, string nodeName)
        {
            string proc = $"Then Tree {treeName} Node {nodeName} CheckBox Is Not Ticked";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Tree.IsTreeNodeNotTicked(treeName, nodeName))
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
