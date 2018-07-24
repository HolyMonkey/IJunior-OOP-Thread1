using System;
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
            Logger logger = new Logger();
            LogEntry entry = new LogEntryError();
        }
    }


    class Logger
    {
        private List<LogEntry> _entities;

        public void Add(LogEntry entry)
        {
            _entities.Add(entry);
        }

        public void Render()
        {
            foreach (var entity in _entities)
            {
                Console.WriteLine(entity.ToHtml());
            }
        }
    }

    abstract class LogEntry
    {
        public string Text;
        public DateTime Time;

        public abstract string ToHtml();
    }

    class LogEntryError : LogEntry
    {
        public override string ToHtml()
        {
            return $"<div style='background-color:red'> <b>{Text}</b> [{Time}] </div>";
        }
    }

    class LogEntryWarrning : LogEntry
    {
        public override string ToHtml()
        {
            return $"<div style='background-color:yellow'> {Text} [<i>{Time}</i>] </div>";
        }
    }
}
