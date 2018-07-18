using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AddingTabs
{
    public class AudioFragment : Fragment
    {

        string myBodyText;

        ListView myList;

        Activity contextLocal;

        String[] myMovies;

        public AudioFragment(Activity context, string value, String[] arrayOfMovies)
        {
            myBodyText = value;
            contextLocal = context;
            myMovies = arrayOfMovies;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Audio, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.myTextId);

            myList = view.FindViewById<ListView>(Resource.Id.listId);

            ArrayAdapter myAdapter = new ArrayAdapter(contextLocal, Android.Resource.Layout.SimpleListItem1, myMovies);

            myList.SetAdapter(myAdapter);

            sampleTextView.Text = "This " + myBodyText;
            return view;
        }
    }
}