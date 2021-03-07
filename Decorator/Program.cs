using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar {Make="BMW",Model="3.20",HidePrice=2500 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("SpecialOffer: {0}",specialOffer.HidePrice);
            Console.WriteLine("Personal Car: {0}", personalCar.HidePrice);
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HidePrice { get; set; }
    }
    abstract class CarDecoratorBase:CarBase
    {
        CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    class PersonalCar:CarBase
    {
        public override string Make { get ; set; }
        public override string Model { get; set; }
        public override decimal HidePrice { get; set; }
    }
    class CommericialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HidePrice { get; set; }
    }
    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        CarBase _carBase;
        public SpecialOffer(CarBase carBase):base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get ; set ; }
        public override string Model { get; set ; }
        public override decimal HidePrice 
        {   get 
            {
                return _carBase.HidePrice - _carBase.HidePrice * DiscountPercentage/100;
            }
            set 
            { 

            }
        }
    }
}
