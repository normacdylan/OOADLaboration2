using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            GoToHistoryButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new HistoryPage());
            };
        }
    }
}
