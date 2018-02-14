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

namespace EloAndroid.Models
{
    public class PlayerAdapter : BaseAdapter<Player>
    {
        List<Player> items;
        Activity context;
        public PlayerAdapter(Activity context, List<Player> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Player this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.PlayerScore, null);
            view.FindViewById<TextView>(Resource.Id.Rank).Text = (position + 1).ToString();
            view.FindViewById<TextView>(Resource.Id.Name).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.Score).Text = item.Score.ToString();

            return view;
        }
    }
}