using MeetAndGit.Models;
using MeetAndGit.Views;
using System;
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
            activityIndicator.IsVisible = true;
            activityIndicator.IsRunning = true;
            searchBtn.IsEnabled = false;

            string errorMessage = null;
            var loc = locEntry.Text.Trim();
            var lang = langEntry.Text.Trim();

            try
            {
                listView.ItemsSource = await App.UserManager.GetUsersAsync(loc, lang);

                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                searchBtn.IsEnabled = true;
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            string errorMessage = null;

            if (args.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
                var user = args.SelectedItem as User;

                DetailsPage detailsPage = new DetailsPage();
                try
                {
                    detailsPage.BindingContext = await App.UserManager.GetUserAsync(user.Login);
                }
                catch (Exception exc)
                {
                    errorMessage = exc.Message;
                }

                await Navigation.PushAsync(detailsPage);
            }
        }
    }
}
