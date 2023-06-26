using Csindex.WebCrawlers.service;
using Microsoft.Win32;
using Quartz;
using Quartz.Impl;
using System;
using System.Windows.Forms;

namespace Csindex.WebCrawlers
{
    public partial class DownloadForm : Form
    {
        public DownloadForm()
        {
            InitializeComponent();
            triggleJobCheckBox.Checked = true;
            startupCheckBox.Checked = true;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            msg.Text = WebCrawlerMainService.DoExcute();
        }

        private void TriggleJob_CheckedChanged(object sender, EventArgs e)
        {
            //调度器,生成实例的时候线程已经开启了，不过是在等待状态
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler().Result;

            //创建一个Job,绑定indicatorJob
            IJobDetail indicatorJob = JobBuilder
                                .Create<WebCrawlerJob>()                     //获取JobBuilder
                                .WithIdentity("indicator", "csindex")  //添加Job的名字和分组
                                .WithDescription("定时更新任务")     //添加描述
                                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                 .StartNow()
                 .ForJob(indicatorJob)
                 .WithIdentity("indicator", "csindex")
                 // 周一到周五的十一点二十分执行
                 .WithCronSchedule("0 20 11 ? * MON-FRI")
                 // 测试用 设置时间间隔，时分秒              
                 //.WithSimpleSchedule(x => x.WithIntervalInSeconds(20).RepeatForever().Build())
                 .Build();
            if (triggleJobCheckBox.Checked)
            {
                Console.WriteLine("自动更新任务准备执行");
                //start让调度线程启动【调度线程可以从jobstore中获取快要执行的trigger,然后获取trigger关联的job，执行job】
                scheduler.Start();
                //将job和trigger注册到scheduler中
                scheduler.ScheduleJob(indicatorJob, trigger).Wait();
            }
            else
            {
                Console.WriteLine("自动更新任务停止执行");
                scheduler.Shutdown();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;//在任务栏中显示该窗口
        }

        private void DownloadForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//当窗体设置值为最小化时
            {
                notifyIcon.Visible = true;//该控件可见
                this.ShowInTaskbar = false;//在任务栏中不显示该窗口
            }
        }

        private void startupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCheckBox.Checked)
            {
                // 本机启动
                RegistryKey R_local = Registry.LocalMachine;
                //RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.SetValue("WebCrawlers", Application.ExecutablePath);
                R_run.Close();
                R_local.Close();
                Console.WriteLine("开机自启动已开启");
            }
            else
            {
                // 本机关闭启动
                RegistryKey R_local = Registry.LocalMachine;
                //RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.DeleteValue("WebCrawlers", false);
                R_run.Close();
                R_local.Close();
                Console.WriteLine("开机自启动已关闭");
            }
        }
    }
}
