using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace TestTopShelf
{
    public class TestAopByAutofac
    {
        public static void Fire()
        {
            var builder = new ContainerBuilder(); 
            //动态注入拦截器 启用类代理拦截
            builder.RegisterType<oo>().As<IShape>().EnableClassInterceptors(); 
            //注册拦截类
            builder.Register(x => new CallLogger()); 
            //创建容器
            var container = builder.Build();
            var cricle = container.Resolve<IShape>(); 
            cricle.Area(); 
            Console.Read();
        }
    }

    /// <summary>
    /// 拦截器 需要实现 IInterceptor接口 Intercept方法
    /// </summary>
    public class CallLogger : IInterceptor
    {

        /// <summary>
        /// 拦截方法 打印被拦截的方法执行前的名称、参数和方法执行后的 返回结果
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {

            Console.WriteLine("你正在调用方法 \"{0}\"  参数是 {1}... ",
              invocation.Method.Name,
              string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            //在被拦截的方法执行完毕后 继续执行
            invocation.Proceed();

            Console.WriteLine("Running");
        }
    }

    public interface IShape
    {
        /// <summary>
        /// 形状的面积
        /// </summary>
        int Area(); 
    }

    [Intercept(typeof(CallLogger))]
    public class Circle : IShape
    { 
        //重写父类抽象方法
        public virtual int Area()
        {
            Console.WriteLine("你正在调用圆求面积的方法,len=");
            return 66;
        } 
    }

    [Intercept(typeof(CallLogger))]
    public class oo : IShape
    {
        public virtual int Area()
        {
            Console.WriteLine($"{nameof(oo)},我是Area");
            return 11;
        }
    }

    public class Water
    {
        public int Color { get; set; }
    }

}
