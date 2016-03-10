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
    [Activity(Label = "HangmanCode")]
    public class HangmanCode : Activity        
     {
        DataBaseManager objDb;
            List<WordDatabase> myList;

        string word;
        int lives = 1;
        ImageView imgHang;
        TextView lblWord;
        LinearLayout linearWord;
        List<TextView> lblWordArraylist = new List<TextView>();
        int score;
        TextView lblScore;
        int lettersguessedright;
        AlertDialog alertdialog;

        static string dbName = "hangbunny.sqlite";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        Button letterA;
        Button letterB;
        Button letterC;
        Button letterD;
        Button letterE;
        Button letterF;
        Button letterG;
        Button letterH;
        Button letterI;
        Button letterJ;
        Button letterK;
        Button letterL;
        Button letterM;
        Button letterN;
        Button letterO;
        Button letterP;
        Button letterQ;
        Button letterR;
        Button letterS;
        Button letterT;
        Button letterU;
        Button letterV;
        Button letterW;
        Button letterX;
        Button letterY;
        Button letterZ;



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.game);

            letterA = FindViewById<Button>(Resource.Id.btnA);
            letterB = FindViewById<Button>(Resource.Id.btnB);
            letterC = FindViewById<Button>(Resource.Id.btnC);
            letterD = FindViewById<Button>(Resource.Id.btnD);
            letterE = FindViewById<Button>(Resource.Id.btnE);
            letterF = FindViewById<Button>(Resource.Id.btnF);
            letterG = FindViewById<Button>(Resource.Id.btnG);
            letterH = FindViewById<Button>(Resource.Id.btnH);
            letterI = FindViewById<Button>(Resource.Id.btnI);
            letterJ = FindViewById<Button>(Resource.Id.btnJ);
            letterK = FindViewById<Button>(Resource.Id.btnK);
            letterL = FindViewById<Button>(Resource.Id.btnL);
            letterM = FindViewById<Button>(Resource.Id.btnM);
            letterN = FindViewById<Button>(Resource.Id.btnN);
            letterO = FindViewById<Button>(Resource.Id.btnO);
            letterP = FindViewById<Button>(Resource.Id.btnP);
            letterQ = FindViewById<Button>(Resource.Id.btnQ);
            letterR = FindViewById<Button>(Resource.Id.btnR);
            letterS = FindViewById<Button>(Resource.Id.btnS);
            letterT = FindViewById<Button>(Resource.Id.btnT);
            letterU = FindViewById<Button>(Resource.Id.btnU);
            letterV = FindViewById<Button>(Resource.Id.btnV);
            letterW = FindViewById<Button>(Resource.Id.btnW);
            letterX = FindViewById<Button>(Resource.Id.btnX);
            letterY = FindViewById<Button>(Resource.Id.btnY);
            letterZ = FindViewById<Button>(Resource.Id.btnZ);
            lblScore = FindViewById<TextView>(Resource.Id.lblScore);

            imgHang = FindViewById<ImageView>(Resource.Id.imgHangman);
            linearWord = FindViewById<LinearLayout>(Resource.Id.linearLayout2);

            // Create your application here

            CopyDatabase();

            objDb = new DataBaseManager();
            myList = objDb.ViewAll();

            ChooseWord();





            // Get our button from the layout resource,
            // and attach an event to it

            letterA.Click += Letter_Click;
            letterB.Click += Letter_Click;
            letterC.Click += Letter_Click;
            letterD.Click += Letter_Click;
            letterE.Click += Letter_Click;
            letterF.Click += Letter_Click;
            letterG.Click += Letter_Click;
            letterH.Click += Letter_Click;
            letterI.Click += Letter_Click;
            letterJ.Click += Letter_Click;
            letterK.Click += Letter_Click;
            letterL.Click += Letter_Click;
            letterM.Click += Letter_Click;
            letterN.Click += Letter_Click;
            letterO.Click += Letter_Click;
            letterP.Click += Letter_Click;
            letterQ.Click += Letter_Click;
            letterR.Click += Letter_Click;
            letterS.Click += Letter_Click;
            letterT.Click += Letter_Click;
            letterU.Click += Letter_Click;
            letterV.Click += Letter_Click;
            letterW.Click += Letter_Click;
            letterX.Click += Letter_Click;
            letterY.Click += Letter_Click;
            letterZ.Click += Letter_Click;

        }

        private void Letter_Click(object sender, EventArgs e)
        {
            string letterbutton = (sender as Button).Text;
            if (word.Contains(letterbutton))
            {

                for (int i = 0; i < word.Length; i++)
                {
                    string letter = word[i].ToString();
                    if (letter == letterbutton)
                    {
                        updateletter(i, letterbutton);
                        score = score + 50;
                        lblScore.Text = "score: " + score;
                        HasPlayerWon();
                        continue;
                    }
                }
            }
            else
            {
                lives = lives + 1;
                score = score - 25;
                lblScore.Text = "score: " + score;
                if (lives == 2)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_2);
                   
                }
                else if (lives == 3)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_3);
                }
                else if (lives == 4)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_4);
                }
                else if (lives == 5)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_5);
                }
                else if (lives == 6)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_6);
                }
                else if (lives == 7)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_7);
                }
                else if (lives == 8)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_8);
                }
                else if (lives == 9)
                {
                    imgHang.SetImageResource(Resource.Drawable.Hangman_9);
                    openprompt();
                }

            }
            Button btnLetter = (sender as Button);
            btnLetter.SetBackgroundColor(Android.Graphics.Color.Transparent);
            btnLetter.Enabled = false;
        }

        public void openprompt()
        {
            alertdialog = new AlertDialog.Builder(this).Create();
            EditText txtEnterName = new EditText(this);

            alertdialog.SetTitle("enter your name");
            alertdialog.SetView(txtEnterName);
            alertdialog.SetButton("submit", (s, ev) =>
            {
                objDb = new DataBaseManager();
                objDb.AddLeaderboard(txtEnterName.Text,score);
                //save to leaderboard
                StartActivity(typeof(Scores));
                Finish();
            }

            );

            alertdialog.SetButton2("main menu", (s, ev) =>
            {
                Finish();
            }

            );
            alertdialog.SetCancelable(false);
            alertdialog.Show();
        }

       
        public void HasPlayerWon()
            //checks if the word has been spelt correctly
        {
            lettersguessedright = lettersguessedright + 1;
            if (lettersguessedright == word.Length)
            {
                openprompt();

                
            }
        }

        public void updateletter(int letterindex, string letterchar)
        {
            lblWordArraylist[letterindex].Text = letterchar;
        }

        static Random rnd = new Random();
        public void CopyDatabase()
        {
            //if (!File.Exists(dbPath))
            //{
                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            //}
        }

        public void ChooseWord()
        {

            var ran = new Random();
            var Wordpicker = ran.Next(0, myList.Count);

            word = myList[Wordpicker].Words;
            word = word.ToUpper();
            //Toast.MakeText(this, word, ToastLength.Long).Show();
            var answerLetters = word.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                lblWord = new TextView(this);
                lblWordArraylist.Add(lblWord);
                lblWord.Text = "_";
                lblWord.Id = i;
                lblWord.SetPadding(15, 5, 15, 5);
                //lblWord.SetPadding(left, top, right, bottom);
                //lblWord.SetTextColor(Color.Black);
                lblWord.TextSize = 20;
                linearWord.AddView(lblWord);


            }
            lblWordArraylist.ToArray();
        }

        public override void OnBackPressed()
        {
            AlertDialog CancelDialog = new AlertDialog.Builder(this).Create();
            CancelDialog.SetTitle("Are you sure you want to quit");
            CancelDialog.SetButton("return", (s, ev) =>
            {
                CancelDialog.Cancel();
            }

            );

            CancelDialog.SetButton2("main menu", (s, ev) =>
            {
                Finish();
            }

            );

            if (CancelDialog != null) 
            {
                if (CancelDialog.IsShowing)
                {
                    CancelDialog.Cancel();


                }
                else
                {
                    CancelDialog.Show();
                }
            }
            else
            {
                CancelDialog.Show();
            }
        }


    }
    
}