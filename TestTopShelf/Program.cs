using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TestTopShelf
{
    public class Program
    {
        private static IContainer Container { get; set; }
        //autofac init on global 
        public static void initAutoFac()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterAssemblyTypes(new Program().GetType().Assembly);

            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>(); 
            builder.RegisterAssemblyTypes(typeof(Program).Assembly);
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            builder.RegisterType<YesterdayWriter>().As<IDateWriter>();
            // builder.Register<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

        }


        public static void Main(string[] args)
        {
            //initAutoFac();

            //1.实在版 2.讨巧版 
            //1： 
            IPerson tim = new Tim();
            tim.HappyTime();

            //2： 
            var build = new ContainerBuilder();
            IContainer Container;

            //注册组件
            build.RegisterType<IPadPro>().As<ISmartDevice>();
            build.RegisterType<Tim1>().As<IPerson>();
            Container = build.Build();

            //解析服务 
            using (var scope = Container.BeginLifetimeScope())
            {
                var tim1 = scope.Resolve<Tim1>();
                tim1.HappyTime();
            }

            //using (var scope = Container.BeginLifetimeScope())
            //{
            //    var w = scope.Resolve<IDateWriter>();
            //    w.WriteDate();
            //}

            //var writer = Container.Resolve<TodayWriter>();
            //writer.WriteDate();

            //想象着从sqlserver切换到orcale或者mysql这些，数据库操作的代码改动量。
            Console.Read();
        }

    }




    public class TownCrier
    {
        void testTopSxhelf()
        {
            HostFactory.New(x =>
            {

                x.Service<TownCrier>(s =>
                {
                    s.ConstructUsing(name => new TownCrier());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                    s.WhenPaused(tc => tc.pause());
                    s.WhenContinued(tc => tc.Continue());

                });

                x.SetDisplayName("sometime you must to do");
                x.SetServiceName("A");
                x.SetDescription("嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻嘻");

            });
            Console.ReadLine();
        }

        public TownCrier()
        {
            //初始化相关配置
        }
        public void Start()
        {
            //启动服务   
            System.IO.File.AppendAllLines(@"d:\winfromOperatorRecord", new string[] { "service started" });
        }

        public void Stop()
        {
            //关闭服务    
            System.IO.File.AppendAllLines(@"d:\winfromOperatorRecord", new string[] { "service closed" });
        }

        public void pause()
        {
            //nothing to do 
            System.IO.File.AppendAllLines(@"d:\winfromOperatorRecord", new string[] { "service pause" });
        }

        public void Continue()
        {
            System.IO.File.AppendAllLines(@"d:\winfromOperatorRecord", new string[] { "service continue" });
        }

    }

}
