using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo
{

    public interface IProduct { }

    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public class SampleFactory
    {
        public IProduct Create(string type)
        {
            if (type == "A")
                return new ConcreteProductA();
            else
                return new ConcreteProductB();
        }
    }
}