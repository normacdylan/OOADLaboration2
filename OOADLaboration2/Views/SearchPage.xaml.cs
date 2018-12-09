using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OOADLaboration2
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            SearchButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new ResultPage());
            };
        }

        // selected = SearchPicker.selectedIndex
    }
}
