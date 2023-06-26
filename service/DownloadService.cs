using Masuit.Tools;
using Masuit.Tools.Net;
using System;
using System.IO;
using System.Net;

namespace Csindex.WebCrawlers
{
    internal class DownloadService
    {
        private String _downloadFilePath = Path.GetTempPath();

        public DownloadService(string downloadFilePath)
        {
            _downloadFilePath = downloadFilePath;
        }
        public DownloadService()
        {
        }

        public String DownloadFileByDownloadLink(String downloadLink, String fileName)
        {
            if (downloadLink.IsNullOrEmpty())
            {
                return null;
            }
            String saveFileName = _downloadFilePath + fileName;
            Console.WriteLine("下载文件路径：" + saveFileName);
            using (var web = new WebClient())
            {
                web.DownloadFile(downloadLink, saveFileName);
            }
            return saveFileName;
        }
    }
}
