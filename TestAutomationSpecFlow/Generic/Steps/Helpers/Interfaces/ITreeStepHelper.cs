using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface ITreeStepHelper : IStepHelper
    {
        bool ClickCheckBox(string treeName, string nodeName);
        int GetNumberOfNodesDisplayed(string treeName);
        string GetTopTreeNodeName(string treeName);
        bool ExpandAll(string treeName, bool expand);
        bool IsDisplayed(string treeName);
        bool IsNodeDisplayed(string treeName, string nodeNameValue);
        bool IsTreeExpandedAtNode(string treeName, string nodeNameValue);
        bool IsTreeNodeTicked(string treeName, string nodeNameValue);
        bool IsTreeNodeHalfTicked(string treeName, string nodeNameValue);
        bool IsTreeNodeNotTicked(string treeName, string nodeNameValue);
        bool NodeToggle(string treeName, string nodeName);
    }
}
