using System;

namespace DelegateSimple
{
    public class DelegateClass
    {
        //declare a delegate Type. This gives the method signature for any method that can be assigned
        //a delegate of this type
        public delegate void SimpleDelegate();

        //now create the instance of the delegate type that you can assign
        //methods to

        public SimpleDelegate mySimpleDelegate;

        public delegate int NotSimpleDelegate(ref string message);
        public NotSimpleDelegate myNotSimpleDelegate;

        //make other methods do anything

        //Action Delegates do not return a value
        //'Action delegateName' is used when it has no parameters
        //'Action<paramType>' is used for delegates with >0 parameters
        public Action myAction {get; set; }
        public Action<int> myActionWithOneParameter {get; set;}

        /* Function delegates take a number of parameters and return a value
        */
        
    }
}