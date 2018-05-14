using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using System;

namespace PracticeEvent_Between2ScreenAndroid
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        //Definitions
        Button EraseButton;
        public bool Flag = false;
        public event EventHandler<MyEventArgsOS> FireEraseEvent;
        ISharedPreferences pref;
        ISharedPreferencesEditor editor; 

        //OnCreate Method
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondLayout);

            //Wire Up
            EraseButton = FindViewById<Button>(Resource.Id.btnInSecondScreen);//linking
            EraseButton.Click += EraseButton_Click;//link user click to an event
            this.FireEraseEvent += SecondActivity_FireEraseEvent;//link event to subscriber
        }

        private void EraseButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("clicking Delete");
            FireEraseEvent.Invoke(this, new MyEventArgsOS() { Erase = true });
            EraseButton.Text = "Delete Event Fired !!!!";
        }
        private void SecondActivity_FireEraseEvent(object sender, MyEventArgsOS e)
        {
            Console.WriteLine("Reach the method of subscriber, Attached Value is :"+ e.Erase);
            MySpecialClassToDealWithEvent mscd = new MySpecialClassToDealWithEvent();
            mscd.ReceivetheEvent(this, e);
            pref = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = pref.Edit();
            editor.PutBoolean("EraseStatus",e.Erase);
            editor.Apply();
        }
    }
}