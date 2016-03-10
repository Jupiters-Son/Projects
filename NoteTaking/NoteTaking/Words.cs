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
using SQLite;

namespace NoteTaking
{
        public class WordDatabase
        {

            [PrimaryKey, AutoIncrement]
            public int wordId { get; set; }
            public string Words { get; set; }


            public WordDatabase()
            {
            }
        }
}