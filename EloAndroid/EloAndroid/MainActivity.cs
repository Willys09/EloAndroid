using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using SQLite;
using EloAndroid.Models;

namespace EloAndroid
{

    [Activity(Label = "Elo Calculator", MainLauncher = true)]
    public class MainActivity : Activity
    {



        List<Player> players = new List<Player>();
        ListView listView;
        DBConnection _connection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            _connection = new DBConnection();


            Button NewPlayer = FindViewById<Button>(Resource.Id.button1);
            NewPlayer.Click += (sender, e) => {
                StartActivity(typeof(NewPlayerActivity));
            };

            //Button consoleWrite = FindViewById<Button>(Resource.Id.button2);
            Button TableErase = FindViewById<Button>(Resource.Id.button2);
            //consoleWrite.Click += (sender, e) =>
            //{
            //    var newPlayer = AddPlayer(conn, "Tim", 1800);
            //    players.Add(newPlayer);
            //    listView.Adapter = new PlayerAdapter(this, players);
            //};

            TableErase.Click += (sender, e) =>
            {
                _connection.Connection.DropTable<Player>();
                Console.WriteLine("Dropped Table");
            };

            listView = FindViewById<ListView>(Resource.Id.myListView);

            players = _connection.GetPlayers();          
            listView.Adapter = new PlayerAdapter(this, players);
        }


    }

    


   


}


