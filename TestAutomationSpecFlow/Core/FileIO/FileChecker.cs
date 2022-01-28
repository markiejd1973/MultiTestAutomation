using Core.Logging;

namespace Core.FileIO
{
    public class FileChecker
    {

        public static bool FileCheck(string pathAndFileName)
        {
            DebugOutput.Log($"proc FileCheck {pathAndFileName}");
            var currentDirectory = Directory.GetCurrentDirectory();
            DebugOutput.Log($"Current Directory is {currentDirectory}");
            if (currentDirectory.Contains("bin") && currentDirectory.Contains("Debug"))
            {
                DebugOutput.Log($"Need to move up directory");
                MoveUpToProjectDirectory();
            }
            return File.Exists(pathAndFileName);
        }

        private static void MoveUpToProjectDirectory()
        {
            Environment.CurrentDirectory = "../../../../";
            DebugOutput.Log($"New Directory is { Directory.GetCurrentDirectory()}");
        }

    }
}
