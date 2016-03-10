using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Collections.Generic;

namespace NoteTaking
{
    [Activity(Label = "NoteTaking", Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        DataBaseManager objDb;
        List<WordDatabase> myList;

        static string dbName = "hangbunny.sqlite";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
        ImageButton btnPlay;
        Button btnScores;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);





            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);
            btnPlay = FindViewById<ImageButton>(Resource.Id.btnPlay);
            btnScores = FindViewById<Button>(Resource.Id.btnScores);
            btnPlay.Click += BtnPlay_Click;
            btnScores.Click += BtnScores_Click;


        }

        private void BtnScores_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Scores));
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanCode));
        }



        



    }
}

