using System;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OOADLaboration2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GoToSearchButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new SearchPage());
            };
        }
    }
}
