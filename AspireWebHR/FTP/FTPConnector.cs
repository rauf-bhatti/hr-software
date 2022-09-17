using System;
using System.Collections.Generic;
using System.Text;
using FluentFTP;
namespace AspireWebHR.FTP
{
    class FTPConnector
    {

        public static int UploadFile(string filePath, string fileSaveName)
        {
            FtpClient client = new FtpClient("167.86.97.216", "storage", "nxM4HZvc6pHKTz0NqkAb3MbS9meue7M9GW0WaX0aqmcnbBG2bnP2eszx968xpsKG");

            client.AutoConnect();

            if (client.IsConnected)
            {
                client.CreateDirectory(FileParser.GetDirectories(fileSaveName));

                FtpStatus ftpResult = client.UploadFile(@filePath, fileSaveName);

                if (FtpStatus.Success == ftpResult)
                {
                    return 1;
                }
                else if (FtpStatus.Skipped == ftpResult)
                {
                    return 0; //Skipped, file already exits
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public static int DownloadFile(string remotefilePath, string savePath)
        {
            FtpClient client = new FtpClient("167.86.97.216", "storage", "nxM4HZvc6pHKTz0NqkAb3MbS9meue7M9GW0WaX0aqmcnbBG2bnP2eszx968xpsKG");
            try
            {
                client.AutoConnect();

                if (client.IsConnected)
                {
                    FtpStatus ftpResult = client.DownloadFile(savePath, remotefilePath);


                    if (FtpStatus.Success == ftpResult)
                    {
                        return 1;
                    }
                    else if (FtpStatus.Skipped == ftpResult)
                    {
                        return 0; //Skipped, file already exits
                    }
                    else
                    {
                        return -1;
                    }
                }
                return -1;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -10;
            }
        }

        public static int DeleteFile(string remotefilePath)
        {
            FtpClient client = new FtpClient("167.86.97.216", "storage", "nxM4HZvc6pHKTz0NqkAb3MbS9meue7M9GW0WaX0aqmcnbBG2bnP2eszx968xpsKG");
            try
            {
                client.AutoConnect();

                if (client.IsConnected)
                {
                    client.DeleteFile(remotefilePath);

                    return 1;
                }
                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -10;
            }
        }
    }
}
