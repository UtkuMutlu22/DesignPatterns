using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("logged");
        }
    }
    class Validation : IValidate
    {
        public void Validete()
        {
            Console.WriteLine("Validate");
        }
    }

    interface IValidate
    {
        void Validete();
    }

    interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

     interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("user chcecked");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }
    class CustomerManager
    {

        CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Validate.Validete();
            Console.WriteLine("saved");
        }
        class CrossCuttingConcernsFacade
        {
            public ILogging Logging;
            public ICaching Caching;
            public IAuthorize Authorize;
            public IValidate Validate;

            public CrossCuttingConcernsFacade()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
                Validate = new Validation();
            }
        }
    }
}
