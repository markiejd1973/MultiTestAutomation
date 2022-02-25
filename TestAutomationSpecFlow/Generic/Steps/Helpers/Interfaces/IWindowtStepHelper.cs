using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IWindowStepHelper : IStepHelper
    {
        bool IsDisplayed(string windowsName);
        bool WriteInWindow(string documentName, string text);
    }
}
