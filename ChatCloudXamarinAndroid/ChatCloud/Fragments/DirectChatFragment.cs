
using Android.App;
using Android.OS;
using Android.Views;

namespace ChatCloud.Fragments
{
    public class DirectChatFragment : Fragment
    {   
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.DirectChatlayout, container, false);
            return view;
        }
    }
}