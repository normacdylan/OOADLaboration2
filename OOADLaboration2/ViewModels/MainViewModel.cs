using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace OOADLaboration2.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigation Navigation;
        private ICommand goToSearchCommand;

        public MainViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            goToSearchCommand = new Command(GoToSearchView);
        }

        public ICommand GoToSearchCommand
        {
            get => goToSearchCommand;
            private set => SetProperty(ref goToSearchCommand, value);
        }

        async void GoToSearchView()
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}
