using Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Targets
{
    public class LoginPage : FormBase
    {
        public LoginPage() : base(By.Id("ip"),"ip page")
        {
            Elements.Add("x", By.Id("AS"));
        }
    }
}
