using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace AddingTabs
{

    class VideoFragment : Fragment
    {
        string myBodyText;

        public VideoFragment(string value)
        {
            myBodyText = value;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.simple_fragment, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView);
            sampleTextView.Text = "This is " + myBodyText;

            return view;
        }
    }

}