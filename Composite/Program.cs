using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee utku = new Employee { Name = "Utku Mutlu" };
            Employee arzu = new Employee { Name = "Arzu Mutlu" };
            Employee fuat = new Employee { Name = "Fuat Mutlu" };
            Employee ahmet = new Employee { Name = "Ahmet" };
            Employee mustafa = new Employee { Name = "Mustafa" };

            utku.AddSubOrdinate(arzu);
            utku.AddSubOrdinate(fuat);
            fuat.AddSubOrdinate(ahmet);
            utku.AddSubOrdinate(mustafa);
            Console.WriteLine(utku.Name);
            foreach (Employee manager in utku)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

        }
    }
    interface IPerson
    {

        public string Name { get; set; }


    }
    class Employee:IPerson,IEnumerable<IPerson>
    {
        public string Name { get; set; }
        List<IPerson> _subOrdinates = new List<IPerson>();
        
        public void AddSubOrdinate(IPerson person)
        {
            _subOrdinates.Add(person);
        }
        public void RemoveSubOrdinate(IPerson person)
        {
            _subOrdinates.Remove(person);
        }

       
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subOrdinate in _subOrdinates)
            {
                yield return subOrdinate;
            }
        }
        public IPerson GetSubOrdinate(int index)
        {
            return _subOrdinates[index];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
