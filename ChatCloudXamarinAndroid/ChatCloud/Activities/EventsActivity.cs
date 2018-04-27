
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using ChatCloud.Activities;

namespace ChatCloud
{
    [Activity(Label = "EventsActivity")]
    public class EventsActivity : AppCompatActivity
    {
        NavigationView navigationView;
        DrawerLayout drawerLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Eventslayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.app_bar);
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
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.menu_radiusChat):
                    StartActivity(new Intent(this, typeof(ChatCloudHomeActivity)));
                    break;
                case (Resource.Id.menu_directChat):
                    StartActivity(new Intent(this, typeof(DirectChatActivity)));
                    break;
                case (Resource.Id.menu_chatGroups):
                    StartActivity(new Intent(this, typeof(ChatGroupsActivity)));
                    break;
                case (Resource.Id.menu_Contacts):
                    StartActivity(new Intent(this, typeof(ContactActivity)));
                    break;
                case (Resource.Id.menu_events):
                    StartActivity(new Intent(this, typeof(EventsActivity)));
                    break;
                case (Resource.Id.menu_invite):
                    StartActivity(new Intent(this, typeof(InviteYourFriendsActivity)));
                    break;
                case (Resource.Id.menu_setting):
                    StartActivity(new Intent(this, typeof(SettingActivity)));
                    break;
                case (Resource.Id.menu_logOut):
                    StartActivity(new Intent(this, typeof(ChatCloudHomeActivity)));
                    break;
            }
            //Close drawer
            drawerLayout.CloseDrawers();
        }

        //add custom icon to tolbar

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            if (menu != null)
            {
                //menu.FindItem(Resource.Id.menu_preferences).SetVisible(true);
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
            SupportActionBar.SetTitle(Resource.String.sEvents);
            base.OnResume();
        }
    }
}