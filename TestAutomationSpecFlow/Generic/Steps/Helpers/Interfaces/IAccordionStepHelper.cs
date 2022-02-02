using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IAccordionStepHelper : IStepHelper
    {
        bool ClickSubElement(string accordionName, string value);
        bool IsDisplayed(string accordionName);
        bool IsElementExtended(string accordionName, string value);
        bool IsElementNotExtended(string accordionName, string value);
    }
}
