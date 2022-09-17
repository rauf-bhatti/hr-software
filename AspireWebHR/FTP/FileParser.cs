using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.FTP
{
    public class FileParser
    {
        public static string GetFile(string filePath)
        {
            int targetIndex = filePath.LastIndexOf("\\") + 1;
            return filePath.Substring(targetIndex, filePath.Length - targetIndex);
        }

        public static string GetDirectories(string filePath)
        {
            int targetIndex = filePath.LastIndexOf("/");
            return filePath.Substring(0, targetIndex);
        }

        public static string GetFileFromFTPString(string filePath)
        {
            int targetIndex = filePath.LastIndexOf("/") + 1;
            return filePath.Substring(targetIndex, filePath.Length - targetIndex);

        }

        public static string RenameFile(string filePath, string desiredName) //Name will be WITHOUT extension!
        {
            string fileName = GetFile(filePath);

            int targetIndex = fileName.LastIndexOf(".");
            string fileExtension = fileName.Substring(targetIndex, fileName.Length - targetIndex);

            return desiredName + fileExtension;
        }
    }
}
