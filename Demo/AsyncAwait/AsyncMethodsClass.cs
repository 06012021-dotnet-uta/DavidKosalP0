using System.Threading.Tasks;
using System;

namespace AsyncAwait
{
    public class AsyncMethodsClass
    {
        

        public async Task<string> Method1(){
            Console.WriteLine("Method1 BT");
            Task task = Task.Delay(1000);
            Console.WriteLine("Method1 AT");

            await task;
            Console.WriteLine("Method1 AAT");
            return "Hello";
        }

        public async Task<int> Method2(){
            Console.WriteLine("Method2 BT");
            Task task = Task.Delay(2000);
            Console.WriteLine("Method2 AT");

            await task;
            Console.WriteLine("Method2 AAT");
            return 1;
        }

        public async Task<Person> Method3(){
            Console.WriteLine("Method3 BT");
            Task task = Task.Delay(3000);
            Console.WriteLine("Method3 AT");

            Person person = new Person() { Fname = "Billy", Lname = "Bob", Age = 31 };
            Person p = person;

            await task;
            Console.WriteLine("Method3 AAT");
            return p;
        }
    }
}