using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AddingTabs
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]

    public class Activity1 : Activity
    {

        string[] myMovies = { "X-Men", "Supper Man" };


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            //adding audio tab
            AddTab("Audio", Resource.Drawable.ic_action_speakers, new AudioFragment(this, "Value for Audio", myMovies));

            //adding video tab 
            AddTab("Video", Resource.Drawable.ic_action_whats_on, new VideoFragment("Value for Video"));

            AddTab("Video 2", Resource.Drawable.ic_action_whats_on, new VideoFragment("Value for Video   2"));


            SetContentView(Resource.Layout.Main);

        }

        /*
         * This method is used to create and add dynamic tab view
         * @Param,
         *  tabText: title to be displayed in tab
         *  iconResourceId: image/resource id
         *  fragment: fragment reference
         * 
        */
        void AddTab(string tabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();

            //tab.SetText(Resource.String.audioId);

            tab.SetCustomView(Resource.Layout.TabLayout);
            tab.CustomView.FindViewById<ImageView>(Resource.Id.tabImage).SetImageResource(iconResourceId);
            tab.CustomView.FindViewById<TextView>(Resource.Id.tabText).Text = tabText;


            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {

                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }

    }
}