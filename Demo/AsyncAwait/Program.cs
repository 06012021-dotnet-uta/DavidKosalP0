using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodsClass amc = new();
            // Task<string> task1 = amc.Method1();
            string method1 = await amc.Method1();
            System.Console.WriteLine($"method1 returned {method1}");
            int method2 = await amc.Method2();
            System.Console.WriteLine($"method2 returned {method2}");
            Person method3 = await amc.Method3();
            System.Console.WriteLine($"method3 returned {method3.Fname} {method3.Lname} {method3.Age}");
            


        }
    }
}
