using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;

namespace JobSchedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Control curRichTx = new Control();

        private void button1_Click(object sender, EventArgs e)
        {
            StartJob();
        }

        void StartJob()
        {
            //声明一个调度器
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            //创建作业
            IJobDetail job1 = JobBuilder.Create<HelloJob>()
                .WithIdentity("作业名称", "jobGroupName")
                .Build();

            //创建一个触发器
            var trigger1 = TriggerBuilder.Create()
                .WithIdentity("触发器名称", "First")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(3)).WithRepeatCount(10))
                .Build();


            //创建作业
            IJobDetail job2 = JobBuilder.Create<HelloJob>()
                .WithIdentity("作业名称", "jobGroupName")
                .Build();

            //创建一个触发器
            var trigger2 = TriggerBuilder.Create()
                .WithIdentity("触发器名称", "First")
                .StartNow()
                .WithCronSchedule("0 15 23 * * ? ")
                .Build();


            scheduler.ScheduleJob(job1, trigger1);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.IO.File.AppendAllLines(@"d:\abccc.txt", new string[] { "窗口关闭，" + DateTime.Now });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.File.AppendAllLines(@"d:\abccc.txt", new string[] { "窗口打开，" + DateTime.Now });
        }
    }

    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Console.wr
            System.IO.File.AppendAllLines(@"d:\abccc.txt", new string[] { DateTime.Now.ToString(), "xx", "----" });

        }
    }
}
