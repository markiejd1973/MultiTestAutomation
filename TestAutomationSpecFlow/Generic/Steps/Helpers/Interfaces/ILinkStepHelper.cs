using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface ILinkStepHelper : IStepHelper
    {
        bool ClickLink(string linkName);
        bool IsDisplayed(string linkName);
    }
}
