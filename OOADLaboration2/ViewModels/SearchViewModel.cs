using System;
using System.Windows.Input;
using OOADLaboration2.Validation;
using Xamarin.Forms;

namespace OOADLaboration2.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ValidatableObject<string> Input { get; set; } = new ValidatableObject<string>();
        string errorMessage;
        int selectedIndex;
        string entry;
        string[] types;
        ICommand searchCommand;
        INavigation Navigation;

        public SearchViewModel(INavigation Navigation)
        {
            entry = "";
            selectedIndex = 0;
            this.Navigation = Navigation;
            Types = new string[] { "music", "movies", "shows", "books", "authors", "games" };
            SearchCommand = new Command(Search);
            AddValidations();
        }

        public string[] Types
        {
            get => types;
            set => SetProperty(ref types, value: value);
        }

        public string Entry
        {
            get => entry;
            set => SetProperty(ref entry, value: value);
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => SetProperty(ref selectedIndex, value: value);
        }

        public ICommand SearchCommand
        {
            get => searchCommand;
            private set => SetProperty(ref searchCommand, value);
        }

        async void Search()
        {
            await Navigation.PushAsync(new ResultPage(entry, Types[selectedIndex]));
        }

        void SearchPressed()
        {
            ValidateSearch();
        }

        public string Error
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        void AddValidations()
        {
            Input.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Search is required."
            });
        }

        bool ValidateSearch()
        {
            return Input.Validate();
        }

    }
}
