using Core.Configuration;
using Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generic.Steps
{
    public class CombinedSteps
    {
        public static bool Failed { get; set; }
        public static int FailedCount { get; set; }

        public static void Failure(string message)
        {
            DebugOutput.Log($"Failure {message}");
            FailedCount += 1;
            Failed = true;
        }

        public static bool OuputProc(string proc, int timeOut = 0)
        {
            DebugOutput.Log(proc);
            if (timeOut == 0)
            {
                timeOut = TargetConfiguration.Configuration.PositiveTimeout;
            }
            //If any previous step has failed and Skip On Failure is true
            if (Failed && TargetConfiguration.Configuration.SkipOnFailure)
            {
                Assert.Inconclusive();
                return false;
            }
            return true;
        }

    }
}
