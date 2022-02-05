using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IButtonStepHelper : IStepHelper
    {
        bool ClickButton(string buttonName);
        bool DoubleClick(string buttonName);
        bool RightClick(string buttonName);
        bool IsDisplayed(string buttonName);

    }
}
