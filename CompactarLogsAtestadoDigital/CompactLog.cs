﻿using System;
using System.IO;
using System.IO.Compression;

namespace CompactarLogsAtestadoDigital
{
    internal static class CompactLog
    {
        public static void Compact(string pathFilesLogs)
        {
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
