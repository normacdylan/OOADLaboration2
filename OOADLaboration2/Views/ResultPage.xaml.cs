using System;
using Xamarin.Forms;
using OOADLaboration2.ViewModels;

namespace OOADLaboration2
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage(string searchWord, string type)
        {
            BindingContext = new ResultViewModel(searchWord, type);
            InitializeComponent();
        }
    }
}