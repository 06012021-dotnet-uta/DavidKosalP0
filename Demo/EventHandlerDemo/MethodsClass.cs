using System;

namespace EventHandlerDemo
{
    public class MethodsClass
    {
        public void OnMessageSend(object source, EventArgs args){
            Console.WriteLine("Add a word to the message");
            string usersMessage = Console.ReadLine();
            args.usersMessage = usersMessage;
        }
    }
}