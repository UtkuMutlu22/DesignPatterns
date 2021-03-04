using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee utku = new Employee { Name="Utku Mutlu"};
            Employee arzu = new Employee { Name = "Arzu Mutlu" };
            utku.AddSubOrdinate(arzu);
            Employee fuat = new Employee { Name = "Fuat Mutlu" };
            utku.AddSubOrdinate(fuat);
            Employee ahmet = new Employee { Name = "Ahmet Mutlu" };
            arzu.AddSubOrdinate(ahmet);

            Contractor ali = new Contractor { Name = "Ali" };
            fuat.AddSubOrdinate(ali);


            Console.WriteLine(utku.Name);
            foreach (Employee manager in utku)
            {
                Console.WriteLine("  {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("     {0}", employee.Name);
                }
            }

        }
    }

    interface IPerson
    {
        string Name { get; set; }

    }
    class Contractor : IPerson
    {
        public string Name { get ; set ; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        public string Name { get ; set ; }
        List<IPerson> _subOrdinates = new List<IPerson>();
        public void AddSubOrdinate(IPerson person)
        {
            _subOrdinates.Add(person);
        }
        public void RemoveSubOrdinate(IPerson person)
        {
            _subOrdinates.Remove(person);
        }
        public IPerson GetSubOrdinate(int index)
        {
            return _subOrdinates[index];
        }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subOrdinate in _subOrdinates)
            {
                yield return subOrdinate;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }



}
