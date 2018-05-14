using System;

namespace PracticeEvent_Between2ScreenAndroid
{
    public class MyEventArgsOS : EventArgs
    {
        private bool _erase;

        public bool Erase { get => _erase; set => _erase = value; }
    }
}