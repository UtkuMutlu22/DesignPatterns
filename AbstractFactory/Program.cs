using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();

        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);

    }
    public class Log4NetLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logging with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logging with NLogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Memcache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager
    {
        CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        Logging _logging;
        Caching _cachehing;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _cachehing = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("logged");
            _cachehing.Cache("data");
            Console.WriteLine("Product Listed");
        }
    }
}
