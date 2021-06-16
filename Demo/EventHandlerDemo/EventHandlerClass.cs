using System;

namespace EventHandlerDemo
{
    public class EventHandlerClass
    {
        
        //1. Crete the delegate type
        public delegate void MessageHandler(object source, EventArgs args);

        //2. Instantiate the delegate
        public event MessageHandler myMessageHandler;

        public void MessageSend(string message){
            message += message;
            OnMessageSend(message);
        }

        public void OnMessageSend(string message){
            if (myMessageHandler != null){
                myMessageHandler(this, new EventArgs() {usersMessage = message});
            }
        }
    }
}