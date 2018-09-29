using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                A obj = new A();
            }
            

            //Console.WriteLine("Age ="+ A.Age);
            Console.Read();

        }
    }

    class A
    {
        public A()
        {
            Console.WriteLine("Constructor of A");
        }

        ~A()
        {
            Console.WriteLine("Destructing instance of A");        
        }
       

       
    
    }
}
