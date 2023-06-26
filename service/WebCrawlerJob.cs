using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csindex.WebCrawlers.service
{
    internal class WebCrawlerJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                //JobDetail的key就是job的分组和job的名字
                Console.WriteLine($"JobDetail的组和名字：{context.JobDetail.Key}");
                WebCrawlerMainService.DoExcute();
            });
        }
    }
}
