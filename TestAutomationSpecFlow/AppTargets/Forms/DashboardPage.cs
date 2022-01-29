using Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Targets.Forms
{
    public class DashboardPage : FormBase
    {
        public DashboardPage() : base(By.Id("dashboard"), "dashboard page")
        {
            Element.Add("Hello", By.XPath("\\."));
        }
    }
}
