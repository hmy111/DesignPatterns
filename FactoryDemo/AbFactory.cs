using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo
{
    // 抽象工厂创建一系列的产品
    public interface IAbFactory
    {
        IProductA CreteProductA();
        IProductB CreteProductB();
    }

    public class ConcreteFactory2 : IAbFactory
    {
        public IProductA CreteProductA()
        {
            return new ProductA2();
        }

        public IProductB CreteProductB()
        {
            return new ProductB2();
        }
    }

    internal class ProductB2 : IProductB
    {
    }

    internal class ProductA2 : IProductA
    {
    }

    // 具体工厂
    public class ConcreteFactory1 : IAbFactory
    {
        public IProductA CreteProductA()
        {
            return new ProductA1();
        }

        public IProductB CreteProductB()
        {
            return new ProductB1();
        }
    }

    internal class ProductB1 : IProductB
    {
    }

    internal class ProductA1 : IProductA
    {
    }

    public interface IProductB
    {
    }

    public interface IProductA
    {
    }
}