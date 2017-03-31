using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetAndGit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "Return");
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Portrait mode. 
            if (Width < Height)
            {
                mainGrid.RowDefinitions[1].Height = GridLength.Auto;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

                Grid.SetRow(detailsStack, 1);
                Grid.SetColumn(detailsStack, 0);
            } 
            // Landscape mode. 
            else
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(detailsStack, 0);
                Grid.SetColumn(detailsStack, 1);
            }
        }

        void OnUrlLabelTapped(object sender, EventArgs args)
        {
            var url = ((Label)sender).Text;

            Device.OpenUri(new Uri(url));
        }
    }
}
