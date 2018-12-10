using System;
using System.Collections.Generic;
using OOADLaboration2.ViewModels;
using Xamarin.Forms;

namespace OOADLaboration2
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            BindingContext = new SearchViewModel(Navigation);
            InitializeComponent();
        }
    }
}
