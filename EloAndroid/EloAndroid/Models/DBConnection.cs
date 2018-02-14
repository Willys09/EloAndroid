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

namespace EloAndroid.Models
{
    public class DBConnection
    {
        private string Folder;
        public SQLiteConnection Connection;

        public DBConnection()
        {
            Folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Connection = new SQLiteConnection(System.IO.Path.Combine(Folder, "Players.db"));

            Connection.CreateTable<Player>();

        }


        public Player AddPlayer(string NameIn, int ScoreIn)
        {
            Player newPlayer = new Player()
            {
                Name = NameIn,
                Score = ScoreIn
            };
            Connection.Insert(newPlayer);
            return newPlayer;
        }


        public List<Player> GetPlayers()
        {
            List<Player> returnList = new List<Player>();
            var tabledPlayers = Connection.Table<Player>().OrderByDescending(t => t.Score);
            foreach(var player in tabledPlayers)
            {
                returnList.Add(player);
            }
            return returnList;
        }



    }
}