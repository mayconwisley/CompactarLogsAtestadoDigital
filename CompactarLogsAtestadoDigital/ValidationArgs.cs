using System.IO;

namespace CompactarLogsAtestadoDigital
{
    internal static class ValidationArgs
    {
        public static void Validation(string[] args)
        {
            string pathFilesLogs = string.Empty;
            bool isDeleteFiles = false;

            // Verifica se tem o parametro de entra
            if (args.Length > 0 && args.Length < 4)
            {
                foreach (var arg in args)
                {
                    if (Path.IsPathRooted(arg))
                    {
                        pathFilesLogs = arg;
                        ProcessCompactLog(pathFilesLogs);
                        continue;
                    }

                    if (args.Length == 3)
                    {

                        if (arg.ToLower() == "del")
                        {
                            isDeleteFiles = true;
                            continue;
                        }
                        var days = int.Parse(arg);
                        ProcessDeleteFile(isDeleteFiles, days, pathFilesLogs);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private static void ProcessCompactLog(string pathFilesLogs)
        {
            CompactLog.Compact(pathFilesLogs);

        }
        private static void ProcessDeleteFile(bool isDeleteFiles, int days, string pathFilesLogs)
        {
            DeleteFile.Delete(isDeleteFiles, days, pathFilesLogs);
        }
    }
}
