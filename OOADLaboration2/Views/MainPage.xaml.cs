using System;
using System.Linq;
using System.Text;
using OOADLaboration2.ViewModels;
using Xamarin.Forms;

namespace OOADLaboration2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel(Navigation);
            InitializeComponent();
        }
    }
}
