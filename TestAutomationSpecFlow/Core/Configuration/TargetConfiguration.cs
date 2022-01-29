using Core.FileIO;
using Core.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Core.Configuration
{
    public class TargetConfiguration
    {
        /// <summary>
        ///     Environment variable that is read to get the target environment name
        /// </summary>
        private const string EnvironmentVariable = "put file name here";
        public static TargetConfigurationData Configuration { get; private set; }

        public class TargetConfigurationData
        {
            public string ApplicationType { get; set; } = "none";
            public string StartUrlx { get; set; } = "none";
            public string StartUrl { get; set; } = "none";
            public string ApiUrl { get; set; } = "none";
            public int PositiveTimeout { get; set; }
            public int NegativeTimeout { get; set; }
            public string DateFormat { get; set; } = "none";
            public string AreaPath { get; set; } = "none";
            public bool OutputOnly { get; set; }
            public bool FeatureFileOnly { get; set; }
            public string ApiDatabaseName { get; set; } = "none";
            public string InstallLocation { get; set; } = "none";
            public int TimeoutMultiplie { get; set; }
            public bool SkipOnFailure { get; set; }
        }

        //public static void TargetConfiguration()
        public static TargetConfigurationData? ReadJson()
        {
            var fileName = $"targetSettings.{Environment}.json";
            var directory = ".\\AppTargets\\Resources\\";
            var fullFileName = directory + fileName;
            if (!FileChecker.FileCheck(fullFileName))
            {
                DebugOutput.Log($"Unable to find the file {fullFileName}");
                return null;
            }
            var jsonText = File.ReadAllText(fullFileName);
            try
            {
                var obj = JsonConvert.DeserializeObject<TargetConfigurationData>(jsonText);
                Configuration = obj;
                DebugOutput.Log($">>>> {obj.AreaPath}  ... {Configuration.AreaPath}");
                return Configuration;
            }
            catch
            {
                DebugOutput.Log($"We out ere");
                return null;
            }
        }


        /// <summary>
        ///     Gets the name of the configured environment.  Defaults to Development, i.e. localhost:4200
        /// </summary>
        private static string Environment =>
            System.Environment.GetEnvironmentVariable(EnvironmentVariable) ?? "development";

    }
}