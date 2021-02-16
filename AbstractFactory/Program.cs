using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
        
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Netlogger");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemmCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("MemCache");
        }
    }
    public abstract class CrossCuttingConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();

    }
    public class Factory1 : CrossCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new MemmCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager
    {
       private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory1;
       private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory1)
        {
            _crossCuttingConcernsFactory1 = crossCuttingConcernsFactory1;
            _logging = _crossCuttingConcernsFactory1.CreateLogger();
            _caching = _crossCuttingConcernsFactory1.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("logged");
            _caching.Cache("Data");

            Console.WriteLine("product Listed");
        }
    }
}
