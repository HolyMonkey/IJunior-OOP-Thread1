using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeLogic someLogic = new SomeLogic(new ConsoleLogger()); //
            SomeLogic someLogic2 = new SomeLogic(new WorkLogger(new ConsoleLogger()));
            SomeLogic someLogic3 = new SomeLogic(new FileLogger());
            SomeLogic someLogic4 = new SomeLogic(new WorkLogger(new FileLogger()));
        }
    }

    class SomeLogic
    {
        private Logger _logger;

        public SomeLogic(Logger logger)
        {
            _logger = logger;
        }

        public void StartUp()
        {
            _logger.Log("I wanna start");
            //

            //
            _logger.Log("Start Is Complete");
        }
    }

    abstract class Logger
    {
        public abstract void Log(string message);
    }

    class ConsoleLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]{message}");
        }
    }

    class FileLogger : Logger
    {
        public override void Log(string message)
        {
            File.WriteAllText("log.txt", $"[{DateTime.Now}]{message}");
        }
    }

    class WorkLogger : Logger
    {
        private Logger _logger;

        public WorkLogger(Logger logger)
        {
            _logger = logger;
        }

        public override void Log(string message)
        {
            if (IsWorkDay())
            {
                _logger.Log(message);
            }
        }

        public bool IsWorkDay()
        {
            var now = DateTime.Now;

            return now.DayOfWeek != DayOfWeek.Sunday && now.DayOfWeek != DayOfWeek.Saturday;
        }
    }
}
