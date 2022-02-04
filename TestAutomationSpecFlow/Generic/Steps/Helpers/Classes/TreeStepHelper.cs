using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class TreeStepHelper : StepHelper, ITreeStepHelper
    {
        private readonly ITargetForms targetForms;
        public TreeStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        int versionNumber = 0;

        private readonly By[] nodes = { By.XPath($"//ol/li") };
        private readonly By[] toggle = { By.XPath($"./span/button") };
        private readonly By[] checkBox = { By.XPath($"./span/label/span[1]") };
        private readonly string[] icon = { $"./span/label/span[2]" };
        private readonly By[] name = { By.XPath($"./span/label/span[3]") };
        private readonly By[] nodeName = { By.XPath($"./span/label/span[3]") };

        private readonly By[] toggleOpen = { By.ClassName("rct-icon-expand-open") };
        private readonly By[] toggleClose = { By.ClassName("rct-icon-expand-close") };

        private readonly By[] checkBoxTicked = { By.ClassName("rct-icon-check") };
        private readonly By[] checkBoxHalfTicked = { By.ClassName("rct-icon-half-check") };
        private readonly By[] checkBoxNoTick = { By.ClassName("rct-icon-uncheck") };

        private readonly By[] expandAll = { By.ClassName("rct-option-expand-all") };
        private readonly By[] collapseAll = { By.ClassName("rct-option-collapse-all") };

        /// <summary>
        /// Is the tree displayed
        /// </summary>
        /// <param name="treeName"></param>
        /// <returns></returns>
        public bool IsDisplayed(string treeName)
        {
            DebugOutput.Log($"IsDisplayed {treeName}");
            treeName = GetTreeName(treeName);
            var treeElement = GetTreeElement(treeName);
            return treeElement.Displayed;
        }

        /// <summary>
        /// Is the indivudal node displayed
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        public bool IsNodeDisplayed(string treeName, string nodeNameValue)
        {
            DebugOutput.Log($"NodeIsDisplayed {treeName} {nodeNameValue}");
            treeName = GetTreeName(treeName);
            var nodeElements = GetNodeList();
            return IsNodeDisplayed(GetNodeList(), nodeNameValue);
        }

        /// <summary>
        /// Is the individual node displayed using IWebElement
        /// </summary>
        /// <param name="nodeElements"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        private bool IsNodeDisplayed(List<IWebElement> nodeElements, string nodeNameValue)
        {
            DebugOutput.Log($"IsNodeDisplayed {nodeElements} {nodeNameValue}");
            var nodeNames = GetNodeNamesFromList(nodeElements);
            foreach (var nodeName in nodeNames)
            {
                if (nodeName.Equals(nodeNameValue)) return true;
            }
            DebugOutput.Log($"Failed to find {nodeNameValue}");
            return false;
        }

        /// <summary>
        /// Is the Nodes Checkbox Ticked
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        public bool IsTreeNodeTicked(string treeName, string nodeNameValue)
        {
            DebugOutput.Log($"IsTreeNodeTicked {treeName} {nodeNameValue}");
            treeName = GetTreeName(treeName);
            var nodeElements = GetNodeList();
            if (!IsNodeDisplayed(nodeElements, nodeNameValue)) return false;
            var nodeNumber = GetNodeNumberForName(nodeNameValue);
            var nodeElement = nodeElements[nodeNumber];  //Node Top Level Element
            var nodeCheckBoxElement = SeleniumUtil.GetElementUnderElement(nodeElement, checkBox[versionNumber]);
            if (nodeCheckBoxElement == null) return false;
            DebugOutput.Log($"Found CheckBox");
            var tickedElement = SeleniumUtil.GetElementUnderElement(nodeCheckBoxElement, checkBoxTicked[versionNumber]);
            if (tickedElement == null) return false;   
            return true;
        }


        /// <summary>
        /// Is the Nodes Checkbox HALF Ticked
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        public bool IsTreeNodeHalfTicked(string treeName, string nodeNameValue)
        {
            DebugOutput.Log($"IsTreeNodeHalfTicked {treeName} {nodeNameValue}");
            treeName = GetTreeName(treeName);
            var nodeElements = GetNodeList();
            if (!IsNodeDisplayed(nodeElements, nodeNameValue)) return false;
            var nodeNumber = GetNodeNumberForName(nodeNameValue);
            var nodeElement = nodeElements[nodeNumber];  //Node Top Level Element
            var nodeCheckBoxElement = SeleniumUtil.GetElementUnderElement(nodeElement, checkBox[versionNumber]);
            if (nodeCheckBoxElement == null) return false;
            DebugOutput.Log($"Found CheckBox");
            var tickedElement = SeleniumUtil.GetElementUnderElement(nodeCheckBoxElement, checkBoxHalfTicked[versionNumber]);
            if (tickedElement == null) return false;
            return true;
        }


        /// <summary>
        /// Is the Nodes Checkbox NOT Ticked
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        public bool IsTreeNodeNotTicked(string treeName, string nodeNameValue)
        {
            DebugOutput.Log($"IsTreeNodeNotTicked {treeName} {nodeNameValue}");
            treeName = GetTreeName(treeName);
            var nodeElements = GetNodeList();
            if (!IsNodeDisplayed(nodeElements, nodeNameValue)) return false;
            var nodeNumber = GetNodeNumberForName(nodeNameValue);
            var nodeElement = nodeElements[nodeNumber];  //Node Top Level Element
            var nodeCheckBoxElement = SeleniumUtil.GetElementUnderElement(nodeElement, checkBox[versionNumber]);
            if (nodeCheckBoxElement == null) return false;
            DebugOutput.Log($"Found CheckBox");
            var tickedElement = SeleniumUtil.GetElementUnderElement(nodeCheckBoxElement, checkBoxNoTick[versionNumber]);
            if (tickedElement == null) return false;
            return true;
        }

        /// <summary>
        /// Is the Node Expanded
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeNameValue"></param>
        /// <returns></returns>
        public bool IsTreeExpandedAtNode(string treeName, string nodeNameValue)
        {
            DebugOutput.Log($"IsTreeExpanded {treeName} {nodeNameValue}");
            treeName = GetTreeName(treeName);
            var nodeElements = GetNodeList();
            if (!IsNodeDisplayed(nodeElements, nodeNameValue)) return false;
            var nodeNumber = GetNodeNumberForName(nodeNameValue);
            var nodeElement = nodeElements[nodeNumber];  //Node Top Level Element
            var nodeToggleElement = SeleniumUtil.GetElementUnderElement(nodeElement, toggleOpen[versionNumber], 2);
            if (nodeToggleElement == null) return false;
            DebugOutput.Log($"Found open Class");
            return true;
        }

        /// <summary>
        /// Return Name of Top Tree Node
        /// </summary>
        /// <param name="treeName"></param>
        /// <returns></returns>
        public string GetTopTreeNodeName(string treeName)
        {
            DebugOutput.Log($"GetTopTreeNodeName {treeName}");
            treeName = GetTreeName(treeName);
            DebugOutput.Log($"tree");
            var treeElement = GetTreeElement(treeName);
            if (treeElement == null) return "";
            var allNodeElements = GetNodeList();
            if (allNodeElements.Count == 0) return "";
            var topNodeElement = allNodeElements[0];
            var nodesNameXPath = nodeName[versionNumber];
            DebugOutput.Log($"Getting nodes");
            var nodeNameElement = SeleniumUtil.GetElementUnderElement(topNodeElement, nodeName[versionNumber]);
            return SeleniumUtil.GetElementText(nodeNameElement);
        }

        /// <summary>
        /// Total number of nodes displayed
        /// </summary>
        /// <param name="treeName"></param>
        /// <returns></returns>
        public int GetNumberOfNodesDisplayed(string treeName)
        {
            DebugOutput.Log($"GetNumberOfNodesDisplayed {treeName}");
            treeName = GetTreeName(treeName);
            DebugOutput.Log($"tree");
            var treeElement = GetTreeElement(treeName);
            if (treeElement == null) return 0;
            return GetNodeList().Count;
        }

        public bool ExpandAll(string treeName, bool expand)
        {
            DebugOutput.Log($"NodeToggle {treeName} {expand}");
            By buttonLocator;
            if (expand)
            {
                buttonLocator = expandAll[versionNumber];
            }
            else
            {
                buttonLocator = collapseAll[versionNumber];
            }
            IWebElement button = SeleniumUtil.GetElement(buttonLocator);
            if (button == null) return false;
            return SeleniumUtil.Click(button);
        }

        /// <summary>
        /// Click on Button for Node to expand OR contract
        /// </summary>
        /// <param name="treeName"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public bool NodeToggle(string treeName, string nodeName)
        {
            DebugOutput.Log($"NodeToggle {treeName} {nodeName}");
            var nodeNumber = GetNodeNumberForName(nodeName);
            if (nodeNumber < 0) return false; //no node found
            DebugOutput.Log($"WE have Node NUMBER {nodeNumber}");
            var nodeElement = GetNodeList()[nodeNumber];  //the node where the name equals nodename
            var nodeToggle = SeleniumUtil.GetElementUnderElement(nodeElement, toggle[versionNumber]);
            if (nodeToggle == null) return false;
            return SeleniumUtil.Click(nodeToggle);
        }

        public bool ClickCheckBox(string treeName, string nodeName)
        {
            DebugOutput.Log($"ClickCheckBox {treeName} {nodeName}");
            var nodeNumber = GetNodeNumberForName(nodeName);
            if (nodeNumber < 0) return false; //no node found
            DebugOutput.Log($"WE have Node NUMBER {nodeNumber}");
            var nodeElement = GetNodeList()[nodeNumber];  //the node where the name equals nodename
            var nodeCheckBox = SeleniumUtil.GetElementUnderElement(nodeElement, checkBox[versionNumber]);
            if (nodeCheckBox == null) return false;
            return SeleniumUtil.Click(nodeCheckBox);
        }
        

        // PRIVATE


        /// <summary>
        /// Using the name get the number of the node (0 is top) Its displayed NODES ONLY!
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private int GetNodeNumberForName(string nodeName)
        {
            DebugOutput.Log($"GetNodeNumberForName {nodeName}");
            var allNodeElements = GetNodeList();
            if (allNodeElements.Count < 0) return -1;
            var allNodeName = GetNodeNamesFromList(allNodeElements);
            int counter = 0;
            foreach(var name in allNodeName)
            {
                DebugOutput.Log($"{counter} {name}");
                if (name == nodeName) return counter;
                counter++;
            }
            return -1;
        }

        /// <summary>
        /// Get a list of all Node Names in order from 0 down
        /// </summary>
        /// <param name="allNodeElements"></param>
        /// <returns></returns>
        private List<string> GetNodeNamesFromList(List<IWebElement> allNodeElements)
        {
            DebugOutput.Log($"GetNodeNamesFromList");
            List<string> nodesNames = new List<string>();
            foreach (var nodeElement in allNodeElements)
            {
                DebugOutput.Log($"Getting name element {nodeName[versionNumber]}");
                var nodeNameElement = SeleniumUtil.GetElementUnderElement(nodeElement, nodeName[versionNumber]);      
                if (nodeNameElement == null) DebugOutput.Log($"We have a node with NO name ELEMENT?");
                DebugOutput.Log($"We have node name element!");
                var text = SeleniumUtil.GetElementText(nodeNameElement);
                if (text == "" || text == SeleniumUtil.failedFindElement) DebugOutput.Log($"We have a node name element - with no text?");
                nodesNames.Add(text);
            }
            return nodesNames;
        }

        /// <summary>
        /// Get a list of all NODE Elements
        /// </summary>
        /// <returns></returns>
        private List<IWebElement> GetNodeList()
        {
            DebugOutput.Log($"GetNodeList");
            var allNodeElements = SeleniumUtil.GetElements(nodes[versionNumber]);
            DebugOutput.Log($"We have {allNodeElements.Count} nodes returned");
            return allNodeElements;
        }

        /// <summary>
        /// Find the tree element
        /// </summary>
        /// <param name="treeName"></param>
        /// <returns></returns>
        private IWebElement GetTreeElement(string treeName)
        {
            DebugOutput.Log($"GetTreeElement {treeName}");
            var treeLocator = CurrentPage.Elements[treeName];
            DebugOutput.Log($"We have the LOCATOR for Tree {treeName} {treeLocator}");
            var element = SeleniumUtil.GetElement(treeLocator);
            DebugOutput.Log($"Tree Element {treeLocator} = {element}");
            return element;
        }

        /// <summary>
        /// Check or Append Tree Name
        /// </summary>
        /// <param name="treeName"></param>
        /// <returns></returns>
        private string GetTreeName(string treeName)
        {
            DebugOutput.Log($"GetTreeName {treeName}");
            treeName = treeName.ToLower();
            if (treeName.Contains("tree")) return treeName;
            return treeName + " tree";
        }


    }
}
