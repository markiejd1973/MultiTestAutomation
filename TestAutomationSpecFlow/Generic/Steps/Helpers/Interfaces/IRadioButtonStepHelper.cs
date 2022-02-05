using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IRadioButtonStepHelper : IStepHelper
    {
        bool IsDisplayed(string radioButtonName);
        bool IsEnabled(string radioButtonName);
        bool IsSelected(string radioButtonName);
        bool Select(string radioButtonName);
    }
}
