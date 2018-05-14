using System;

namespace PracticeEvent_Between2ScreenAndroid
{
    public class MySpecialClassToDealWithEvent
    { 
        public void ReceivetheEvent(object source, MyEventArgsOS myEventArgs)
        {
            Console.WriteLine("Inside the ReceivetheEvent class and status is:" + myEventArgs.Erase); 
        } 
    }
}

