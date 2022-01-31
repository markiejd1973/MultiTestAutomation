using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IStepHelpers
    {
        IButtonStepHelper Button { get; }

    }

    public interface IStepHelper
    {
        FormBase CurrentPage { get; set; } 
    }
}


