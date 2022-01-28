using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TestRunProperties
    {

        public string appType { get; set; } = "";

        public TestRunProperties(string apptype)
        {
            appType = apptype;
        }

    }
}
