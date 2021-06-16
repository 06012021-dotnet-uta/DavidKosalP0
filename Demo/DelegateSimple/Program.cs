using System;

namespace DelegateSimple
{
    public class MethodsClass{
        public void method1(){
            Console.WriteLine($"This is method 1.");
        }
        public void method2(){
            Console.WriteLine($"This is method 2.");
        }
        public void method3(){
            Console.WriteLine($"This is method 3.");
        }
        public int method4(ref string message){
            Console.WriteLine($"This is method 4. Add something to the message");
            return 1;
        }

        public int method5(ref string message){
            Console.WriteLine($"Method 5. Add something to the message");
            string m = Console.ReadLine();
            message += m;
            return 2;

        }

        public int method6(ref string message){
            Console.WriteLine($"Method 6. Add something to the message");
            string m = Console.ReadLine();
            message += m;
            return 3;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegateClass = new DelegateClass();

            //add methods with = then +
            MethodsClass myMethodsClass = new MethodsClass();
            // myDelegateClass.mySimpleDelegate = myMethodsClass.method1;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.method2;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.method3;

            // //delete methods with = then -
            // myDelegateClass.mySimpleDelegate -= myMethodsClass.method2;


            //myDelegateClass.mySimpleDelegate();
            //Console.WriteLine(myDelegateClass.mySimpleDelegate.GetInvocationList().ToString());

            myDelegateClass.myNotSimpleDelegate = myMethodsClass.method4;
            myDelegateClass.myNotSimpleDelegate += myMethodsClass.method5;
            myDelegateClass.myNotSimpleDelegate += myMethodsClass.method6;


            string myString = "This";
            int result = myDelegateClass.myNotSimpleDelegate(ref myString);
            Console.WriteLine($"the result is => {result}");
            Console.WriteLine($"the string is now => {myString}");



        }
    }
}
