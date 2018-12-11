using System;
using System.Collections.Generic;
using System.Linq;
using OOADLaboration2.ViewModels;

namespace OOADLaboration2.Validation
{
    public class ValidatableObject<T> : BaseViewModel, IsValid
    {
        T _value;
        List<string> _errors;
        public List<IValidationRule<T>> Validations { get; }

        public T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public List<string> Errors
        {
            get { return _errors; }
            set { SetProperty(ref _errors, value); }
        }

        public bool IsValid { get; set; }

        public ValidatableObject()
        {
            IsValid = true;
            _errors = new List<string>();
            Validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();
            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value)).Select(v => v.ValidationMessage);
            Errors = errors.ToList();
            IsValid = !Errors.Any();
            return IsValid;
        }
    }
}
