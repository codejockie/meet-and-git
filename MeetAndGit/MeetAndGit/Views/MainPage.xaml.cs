using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeetAndGit
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            if (locEntry.Text != string.Empty && langEntry.Text != string.Empty)
            {
                var location = locEntry.Text;
                var language = langEntry.Text;

                listView.ItemsSource = await App.UserManager.GetUsersAsync(location, language);
            }
        }
    }
}
