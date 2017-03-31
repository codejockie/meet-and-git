using MeetAndGit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MeetAndGit
{
    public partial class App : Application
    {
        public static UsersManager UserManager { get; set; }

        public App()
        {
            InitializeComponent();

            UserManager = new UsersManager(new RestService());

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Accent,
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
