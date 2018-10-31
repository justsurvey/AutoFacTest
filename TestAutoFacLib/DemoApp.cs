using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoFacLib
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

    public class FileOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine("文件output:" + content);
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




}
