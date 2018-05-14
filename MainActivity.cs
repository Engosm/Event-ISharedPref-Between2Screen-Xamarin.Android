using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Preferences;

namespace PracticeEvent_Between2ScreenAndroid
{
    [Activity(Label = "PracticeEvent_Between2ScreenAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button BtnInMainActivity;
        ISharedPreferences pref;
        ISharedPreferencesEditor editor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Linking
            var GoToSecondScreen = FindViewById<Button>(Resource.Id.btnGoToSecondScreen);
            BtnInMainActivity = FindViewById<Button>(Resource.Id.btnInMainActivity);
            
            //if click send the user to the next screen
            GoToSecondScreen.Click += GoToSecondScreen_Click;
        }

        private void GoToSecondScreen_Click(object sender,EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            this.StartActivity(intent);
        }
        
        //when user return back from another screen OnResume will be executed
        //The EraseEvent can't be submitted here, We could use intent.putextra & getstring
        protected override void OnResume()
        {
            base.OnResume();
            
            Console.WriteLine("We are in OnResume method");
             pref = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = pref.Edit();
            bool EraseEventStatus = pref.GetBoolean("EraseStatus", false);
            Console.WriteLine(" Erase Event Status is "+EraseEventStatus);//earse the data base
            
        }
    }
}

