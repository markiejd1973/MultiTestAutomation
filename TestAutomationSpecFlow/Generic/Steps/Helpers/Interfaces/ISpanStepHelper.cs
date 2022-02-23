using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface ISpanStepHelper : IStepHelper
    {
        bool ClickOnLinkByName(string linkName);
        bool LinkDisplayedByName(string linkName);
    }
}
