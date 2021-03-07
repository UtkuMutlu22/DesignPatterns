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
    class Logging:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogger
    {
        void Log();
    }
    class Caching : ICaching
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
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checed user");
        }
    }
    interface IAuthorize
    {
        void CheckUser();
    }
    class Validate : IValidate
    {
        public void Validation()
        {
            Console.WriteLine("Validated");
        }
    }
    interface IValidate
    {
        void Validation();
    }
    class CustomerManager
    {

        private CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            _concerns.Validate.Validation();
            Console.WriteLine("Saved");
        }
    }
    class CrossCuttingConcernsFacade
    {
        public ILogger Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validate();
        }
    }
}
