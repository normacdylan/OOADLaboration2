using System;
using System.Windows.Input;
using OOADLaboration2.Validation;
using Xamarin.Forms;

namespace OOADLaboration2.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ValidatableObject<string> SearchInput { get; set; } = new ValidatableObject<string>();
        public ICommand SearchButton { get; set; }
        string _errorMessage;

        public SearchViewModel()
        {
            SearchButton = new Command(SearchButtonPressed);
            AddValidations();
        }

        void SearchButtonPressed()
        {
            ValidateSearchInput();
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        void AddValidations()
        {
            SearchInput.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Search is required."
            });
        }

        bool ValidateSearchInput()
        {
            return SearchInput.Validate();
        }
    }
}
