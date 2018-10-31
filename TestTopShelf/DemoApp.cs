using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTopShelf
{

    public interface IOutput
    {
        void Write(string content);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine("控制台output:" + content);
        }
    }

    public interface IDateWriter
    {
        void WriteDate();
    }

    public class TodayWriter : IDateWriter
    {
        IOutput _op;
        public TodayWriter(IOutput op)
        {
            this._op = op;
        }

        public void WriteDate()
        {
            this._op.Write(DateTime.Today.ToShortDateString());
        }
    }

    public class YesterdayWriter : IDateWriter
    {
        IOutput _op;
        public YesterdayWriter(IOutput op)
        {
            this._op = op;
        }


        public void WriteDate()
        {
            this._op.Write(DateTime.Now.ToShortDateString() + "-1");
        }
    }

    //画画，抽象 白板，=》ipad pro ,白纸 

    public interface ISmartDevice
    {
        void PlayGame();
    }

    public class IPhone : ISmartDevice
    {
        public void PlayGame() =>
            Console.WriteLine($"用{nameof(IPhone)}玩王者荣耀，屏幕很清晰，给力"); 
    }

    public class IPadPro : ISmartDevice
    {
        public void PlayGame() =>
            Console.WriteLine($"用{nameof(IPadPro)}玩王者荣耀,视野宽广,Carry 全场");
    }


    public class Tim : IPerson
    { 
        public void HappyTime() => new IPhone().PlayGame(); 
    }

    public interface IPerson
    {
        void HappyTime();
    }

    public class Tim1 : IPerson
    {
        ISmartDevice _sd;
        public Tim1(ISmartDevice sd)
        {
            this._sd = sd;
        }

        public void HappyTime()
        {
            _sd.PlayGame();
        }

    }





}
