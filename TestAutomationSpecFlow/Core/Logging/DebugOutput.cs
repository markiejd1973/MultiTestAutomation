using System;
using System.Diagnostics;

namespace Core.Logging
{
    public static class DebugOutput
    {

        public static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
