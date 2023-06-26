using Masuit.Tools;
using NSoup.Nodes;
using System;
using System.Collections.Generic;

namespace Csindex.WebCrawlers.service
{
    internal static class WebCrawlerMainService
    {
        public static String DoExcute()
        {
            String defaltPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Console.WriteLine(defaltPath);
            var seleniumService = new SeleniumService();
            Document document = seleniumService.GetHtmlPageByUrl("https://www.csindex.com.cn/index.html#/indices/family/detail?indexCode=000969");
            if (document == null)
            {
                return "获取页面失败！";
            }
            List<String> downloadLinksByHtmlDocument = HtmlService.GetDownloadLinksByPageDocument(document);
            String downloadLink = "";
            if (!downloadLinksByHtmlDocument.IsNullOrEmpty())
            {
                for (int i = 0; i < downloadLinksByHtmlDocument.Count; i++)
                {
                    Console.WriteLine(downloadLinksByHtmlDocument[i]);
                    if (i > 9)
                    {
                        break;
                    }
                    if (downloadLinksByHtmlDocument[i].Contains("indicator"))
                        downloadLink = downloadLinksByHtmlDocument[i];
                }
            }
            Console.WriteLine(downloadLink);
            if (downloadLink.IsNullOrEmpty())
            {
                return "获取链接失败！";
            }
            String fileName = downloadLink.Substring(downloadLink.LastIndexOf("/") + 1);
            DownloadService downloadService = new DownloadService();
            String saveFilePath = downloadService.DownloadFileByDownloadLink(downloadLink, fileName);
            ExcelService excelService = new ExcelService();
            String destFileName = defaltPath + "\\" + fileName;
            excelService.MergeExcelData(saveFilePath, destFileName);
            return "合并成功！位置：" + destFileName;
        }
    }
}
