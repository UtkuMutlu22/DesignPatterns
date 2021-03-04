using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
        }
    }
    
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }

    }
    public class LoggerFactory2:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new LogForNetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Edlogger");
        }
    }
    public class LogForNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogForNet");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
