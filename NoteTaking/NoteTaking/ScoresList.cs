using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace NoteTaking
{
    public class ScoresList
    {
        [PrimaryKey, AutoIncrement]
        public string Name { get; set; }
        public int Score { get; set; }

        public ScoresList()
        {
        }
    }
}