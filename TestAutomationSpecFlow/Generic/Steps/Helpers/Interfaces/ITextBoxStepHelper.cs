using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface ITextBoxStepHelper : IStepHelper
    {
        bool ClearThenEnterText(string textBoxName, string text);
        string GetText(string textBoxName);
        bool EnterText(string textBoxName, string text, string key = null);
        bool EnterTextAndKey(string textBoxName, string text, string key);
        bool IsDisplayed(string textBoxName);
    }
}
