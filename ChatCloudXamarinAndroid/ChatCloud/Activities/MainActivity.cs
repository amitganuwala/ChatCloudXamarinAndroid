
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using ChatCloud.Fragments;

namespace ChatCloud.Activities
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        NavigationView navigationView;
        DrawerLayout drawerLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Mainlayout); 
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);

            drawerToggle.SyncState();

            View header = navigationView.GetHeaderView(0);

        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var ft = FragmentManager.BeginTransaction();
            Fragment fragment = null;
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.menu_radiusChat):
                    fragment = new RadiusChatFragment();
                    break;
                case (Resource.Id.menu_directChat):
                    fragment = new DirectChatFragment();
                    break;
            }


            //replacing the fragment
            if (fragment != null)
            {
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
                drawerLayout.CloseDrawers();
            }       
        }

        //add custom icon to tolbar

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            if (menu != null)
            {
                menu.FindItem(Resource.Id.menu_preferences).SetVisible(true);
                menu.FindItem(Resource.Id.actionsearch).SetVisible(true);
            }
            return base.OnCreateOptionsMenu(menu);
        }

        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
            {
                FragmentManager.PopBackStack();// fragmentManager.popBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }


        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.sRadiusChat);
            base.OnResume();
        }
    }
}