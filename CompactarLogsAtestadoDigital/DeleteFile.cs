using System;
using System.IO;

namespace CompactarLogsAtestadoDigital
{
    internal class DeleteFile
    {
        public static void Delete(bool isDeleteFiles, int days, string pathFilesLogs)
        {
            //Caso tenha o parametro "Del" com a "quantidade de dias" ira deletar os arquivos da quantidade de dias para trás.
            if (isDeleteFiles)
            {
                var filesDirectory = Directory.GetFiles(pathFilesLogs, "*.zip", SearchOption.TopDirectoryOnly);

                foreach (var file in filesDirectory)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    var daysDifference = DateTime.Now.Date - fileInfo.LastWriteTime.Date;

                    if (daysDifference.Days >= days)
                    {
                        File.Delete(fileInfo.FullName);
                    }
                }
            }
        }
    }
}
