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
using EloAndroid.Models;

namespace EloAndroid
{
    [Activity(Label = "New Player")]
    public class NewPlayerActivity : Activity
    {
        DBConnection _connection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewPlayer);
            _connection = new DBConnection();

            Button NewPlayerBtn = FindViewById<Button>(Resource.Id.SavePlayer);
            EditText NewNametext = FindViewById<EditText>(Resource.Id.PlayerName);
            EditText ScoreText = FindViewById<EditText>(Resource.Id.Score);
            TextView Errortext = FindViewById<TextView>(Resource.Id.ErrorText);

            NewPlayerBtn.Click += (sender, e) =>
            {
                int score = 0;
                bool hasError = false;
                if (string.IsNullOrWhiteSpace(NewNametext.Text))
                {
                    Errortext.Text = "Player needs to have a name";
                    hasError = true;
                }
                try
                {
                    score = Convert.ToInt32(ScoreText.Text);
                }
                catch(Exception)
                {
                    hasError = true;

                }

                if (!hasError && score > 0)
                {
                    _connection.AddPlayer(NewNametext.Text, score);
                    StartActivity(typeof(MainActivity));
                }
            };
        }
    }
}