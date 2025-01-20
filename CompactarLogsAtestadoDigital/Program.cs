using System;
using System.IO;
using System.IO.Compression;

namespace CompactarLogsAtestadoDigital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathFilesLogs;

            // Verifica se tem o parametro de entra do log
            if (args.Length > 0)
            {
                pathFilesLogs = args[0];
            }
            else
            {
                return;
            }
            string zipPath = Path.Combine(pathFilesLogs, $@"{DateTime.Now:yyyy_MM} Logs Compentencia.zip");
            var filesDirectory = Directory.GetFiles(pathFilesLogs, "*.txt", SearchOption.TopDirectoryOnly);

            // Cria um arquivo zip vazio
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (var file in filesDirectory)
                    {
                        // Adiciona arquivos individualmente
                        archive.CreateEntryFromFile(file, Path.GetFileName(file));
                    }
                }
            }
        }
    }
}
