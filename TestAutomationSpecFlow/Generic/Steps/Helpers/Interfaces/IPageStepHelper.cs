using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IPageStepHelper : IStepHelper
    {
        IWebElement GetPageElement(string pageName, string elementName);
        bool IsDisplayed(string pageName);
        void SetCurrentPage(string pageName);
    }
}
