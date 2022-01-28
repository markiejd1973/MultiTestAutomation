
namespace AppTargets.Configuration
{
    public class TargetSettings
    {
        public string StartUrl { get; set; }
        public string ApiUrl { get; set; }
        //public DebugLevel DebugLevel { get; set; }
        public int PositiveTimeout { get; set; }
        public int NegativeTimeout { get; set; }
        public string DateFormat { get; set; }
        public string AreaPath { get; set; }
        public bool OutputOnly { get; set; }
        public bool FeatureFileOnly { get; set; }
        public string ApiDatabaseName { get; set; }
        public string ApplicationType { get; set; }
        public string InstallLocation { get; set; }
        public int TimeoutMultiplier { get; set; }
    }
}