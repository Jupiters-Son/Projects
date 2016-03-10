using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;


namespace NoteTaking
{
    [Activity(Label = "Scores")]
    public class Scores : Activity
    {
        ListView ListLeaderBoard;
        Button btnReturn;

        List<ScoresList> scoreslist;
        DataBaseManager objDb;

        static string dbNameLeader = "Hangbunny.sqlite";
        string dbPathLeader = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbNameLeader);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Scores);

            ListLeaderBoard = FindViewById<ListView>(Resource.Id.listView1);
            btnReturn = FindViewById<Button>(Resource.Id.btnReturn);

            objDb = new DataBaseManager();

            scoreslist = objDb.ViewLeaderboard();

            ListLeaderBoard.Adapter = new DataAdapter(this, scoreslist);

            btnReturn.Click += BtnReturn_Click;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        
    }
}