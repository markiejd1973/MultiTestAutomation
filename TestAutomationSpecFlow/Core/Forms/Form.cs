using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    public abstract class Form
    {
        public By Locator
        {
            get;
        }

        public string Name
        {
            get;
        }


        protected Form(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }
    }
}
