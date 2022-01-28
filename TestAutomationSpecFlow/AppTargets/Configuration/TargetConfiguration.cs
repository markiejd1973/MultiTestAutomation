using System.Text.Json;
using System.Text.Json.Nodes;

namespace AppTargets.Configuration
{
    public class TargetConfiguration
    {
        /// <summary>
        ///     Environment variable that is read to get the target environment name
        /// </summary>
        private const string EnvironmentVariable = "put file name here";
        public string Name { get; set; }
        public int Year { get; set; }

        public class RootObject
        {
            public string companyName { get; set; }
            public string companyNumber { get; set; }
        }

        //private TargetConfiguration()
        //{
        //    var fileName = $"targetSettings.{Environment}.json";
        //    var dataPath = @$".\AppTargets\Resources\{fileName}";
        //    using (StreamReader r = new StreamReader(dataPath))
        //    {
        //        string jsonRead = r.ReadToEnd();
        //    }
        //    string jsonString = "{\"a\": 1,\"b\": \"string value\",\"c\":[{\"Value\": 1}, {\"Value\": 2,\"SubObject\":[{\"SubValue\":3}]}]}";

        //    JsonValue json = JsonValue.Parse(jsonString);
        //}


        /// <summary>
        ///     Gets the name of the configured environment.  Defaults to Development, i.e. localhost:4200
        /// </summary>
        private string Environment =>
            System.Environment.GetEnvironmentVariable(EnvironmentVariable) ?? "development";

        public TargetSettings Settings { get; }

    }
}