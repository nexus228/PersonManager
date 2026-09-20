using PersonManager_WPF_CLIENT.Command;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services;

namespace PersonManager_WPF_CLIENT.ViewModel
{
    internal class EditWindowViewModel : ViewModelBase
    {

        #region private fields
        private Person _personToEdit;

        private readonly IPersonService _personService;

        private string _firstNameToEdit = string.Empty;

        private string _nameToEdit = string.Empty;

        private DateTime _dateOfBirthToEdit;

        private bool _isLoading = false;

        #endregion

        public string FirstNameToEdit
        {
            get
            {
                return _firstNameToEdit;
            }
            set
            {
                _firstNameToEdit = value;
                OnPropertyChanged(nameof(FirstNameToEdit));

                if(SaveChangesCommand != null)
                    SaveChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public string NameToEdit
        {
            get
            {
                return _nameToEdit;
            }
            set
            {
                _nameToEdit = value;
                OnPropertyChanged(nameof(NameToEdit));

                if (SaveChangesCommand != null)
                    SaveChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime DateOfBirthToEdit
        {
            get
            {
                return _dateOfBirthToEdit;
            }
            set
            {
                _dateOfBirthToEdit = value;

                OnPropertyChanged(nameof(DateOfBirthToEdit));

                if (SaveChangesCommand != null)
                    SaveChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            private set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public BaseCommand SaveChangesCommand { get; private set; }

        public EditWindowViewModel(Person personToEdit, IPersonService personService)
        {
            _personToEdit = personToEdit;
            _personService = personService;

            if(_personToEdit.FirstName != null)
                FirstNameToEdit = _personToEdit.FirstName;

            if (_personToEdit.Name != null)
                NameToEdit = _personToEdit.Name;

            if (_personToEdit.DateOfBirth != null)
                DateOfBirthToEdit = new DateTime(_personToEdit.DateOfBirth.Value.Year,
                    _personToEdit.DateOfBirth.Value.Month, 
                    _personToEdit.DateOfBirth.Value.Day);

            SaveChangesCommand = new BaseCommand(SaveChanges, CanSaveChanges);
        }

        private bool CanSaveChanges()
        {
            // Check for Changes in EditTextFields or Date is changed
            // DatePicker is working with DateTime, Model Date is DateOnly so we have to do switch between this two formats ... 

            bool returnValue = false;

            if(FirstNameToEdit.Equals(_personToEdit.FirstName) == false || NameToEdit.Equals(_personToEdit.Name) == false)
            {
                returnValue = true;
            }
            if (_personToEdit.DateOfBirth != null && !DateOfBirthToEdit.Equals(
                new DateTime(_personToEdit.DateOfBirth.Value.Year, 
                _personToEdit.DateOfBirth.Value.Month, 
                _personToEdit.DateOfBirth.Value.Day)))
            {
                returnValue = true;
            }
            return returnValue;        
        }

        private async void SaveChanges()
        {

            IsLoading = true;

            Person personToUpdate = new Person()
            {
                Id = _personToEdit.Id,
                FirstName = FirstNameToEdit,
                Name = NameToEdit,
                DateOfBirth = DateOnly.FromDateTime(DateOfBirthToEdit),
                Addresses = _personToEdit.Addresses,
                PhoneConnections = _personToEdit.PhoneConnections
            };

            await _personService.UpdatePersonAsync(personToUpdate);

            IsLoading = false;
        }
    }
}
