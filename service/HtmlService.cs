using Masuit.Tools;
using NSoup.Nodes;
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csindex.WebCrawlers
{
    internal static class HtmlService
    {

       /**
        * 获取网页 相关资料的下载链接列表
        *
        * @param document 网页数据
        * @return 下载链接列表
        */
        public static List<String> GetDownloadLinksByPageDocument(Document document)
        {
            if (document == null)
            {
                Console.Write("获取HTML文件失败!");
                return new List<String>();
            }
            Console.Write("开始解析页面中的下载链接");
            Elements downloadDivElement = document.Body.GetElementsByClass("material-list-item");
            List<String> downloadLinks = new List<string>(6);
            foreach (Element element in downloadDivElement)
            {
                Element downloadLinkElement = element.Select("a[href]").First();
                if (downloadLinkElement == null)
                {
                    continue;
                }
                String downloadLink = downloadLinkElement.Attr("href");
                if (!downloadLink.IsNullOrEmpty())
                {
                    downloadLinks.Add(downloadLink);
                }
            }
            return downloadLinks;
        }
    }
}
