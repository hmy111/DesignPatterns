using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo
{
    // 具体的工厂创建具体的实体
    public interface IFactory
    {
        IMethodProduct CreateProduct();
    }


    public class FactoryA : IFactory
    {
        public IMethodProduct CreateProduct()
        {
            return new MethodProductA();
        }
    }

    public class FactoryB : IFactory
    {
        public IMethodProduct CreateProduct()
        {
            return new MethodProductB();
        }
    }

    internal class MethodProductB : IMethodProduct
    {
    }

    internal class MethodProductA : IMethodProduct
    {
    }

    public interface IMethodProduct { }
}