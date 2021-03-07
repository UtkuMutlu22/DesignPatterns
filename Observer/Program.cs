using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdutManagerer produtManager = new ProdutManagerer();
            var customerObserver = new CustomerObserver();
            produtManager.Attach(customerObserver);
            produtManager.Attach(new EmployeeObserver());

            produtManager.Detach(customerObserver);
            produtManager.UpdatePrice();
        }
    }
    class ProdutManagerer
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver:Observer
    {
        public override void Update()
        {
            Console.WriteLine("Product price to customer: Product price changed");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Product price to employee: Product price changed");
        }
    }

}
