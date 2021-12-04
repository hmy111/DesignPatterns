using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo
{
    public class Singleton1
    {
        private Singleton1() { }

        public static Singleton1 Instance = new Singleton1();

        public static int a = 2;
    }
}