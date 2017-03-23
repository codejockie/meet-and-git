using MeetAndGit.Models;
using MeetAndGit.Views;
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

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (locEntry.Text != string.Empty && langEntry.Text != string.Empty)
            {
                var loc = locEntry.Text.Trim();
                var lang = langEntry.Text.Trim();

                listView.ItemsSource = await App.UserManager.GetUsersAsync(loc, lang);
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as User;

            DetailsPage detailsPage = new DetailsPage();
            var userInfo = await App.UserManager.GetUserAsync(user.Login);
            detailsPage.BindingContext = userInfo;

            await Navigation.PushAsync(detailsPage);
        }
    }
}
