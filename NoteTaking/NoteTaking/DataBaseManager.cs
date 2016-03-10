using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NoteTaking
{
    class DataBaseManager
    {
        static string dbName = "hangbunny.sqlite";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        public DataBaseManager()
        {
        }

        public List<WordDatabase> ViewAll()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "Select * from tblWords";
                    var NoteList = cmd.ExecuteQuery<WordDatabase>();
                    return NoteList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }

        public void AddLeaderboard(string name, int score)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "insert into tblScores(Name, Score) values('" + name + "','" + score + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
        }
        public List<ScoresList> ViewLeaderboard()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "Select * from tblScores ORDER BY Score DESC;";
                    var LeaderboardList = cmd.ExecuteQuery<ScoresList>();
                    return LeaderboardList;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }

    }
}