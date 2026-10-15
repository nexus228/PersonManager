using PersonManager_WPF_CLIENT.Command;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services;
using PersonManager_WPF_CLIENT.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PersonManager_WPF_CLIENT.ViewModel
{
    internal class CreatePersonWindowViewModel : ViewModelBase
    {
        #region private fields
        private IPersonService _personService;

        private string _firstName = string.Empty;

        private string _name = string.Empty;

        private DateTime? _dateOfBirth = null;

        private bool _isLoading = false;

        #endregion

        #region public properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));

                if (CreatePersonCommand != null)
                    CreatePersonCommand.RaiseCanExecuteChanged();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));

                if (CreatePersonCommand != null)
                    CreatePersonCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;

                OnPropertyChanged(nameof(DateOfBirth));

                if (CreatePersonCommand != null)
                    CreatePersonCommand.RaiseCanExecuteChanged();
            }
        }


        public ObservableCollection<Address> Addresses { get; } = new ObservableCollection<Address>();

        public ObservableCollection<PhoneConnection> PhoneConnections { get; } = new ObservableCollection<PhoneConnection>();

        public BaseCommand AddAddressCommand { get; }
        public BaseCommand AddPhoneNumberCommand { get; }

        public BaseCommand CreatePersonCommand { get; private set; }

        #endregion


        public CreatePersonWindowViewModel(IPersonService personService)
        {
            _personService = personService;

            CreatePersonCommand = new BaseCommand(CreatePerson, CanCreatePerson);
            AddAddressCommand = new BaseCommand(AddAddress);
            AddPhoneNumberCommand = new BaseCommand(AddPhoneNumber);
        }


        #region private methods

        private void AddAddress()
        {
            Address newAddress = new Address { City = String.Empty, HouseNumber = String.Empty, Street = String.Empty, ZipCode = String.Empty };
            Addresses.Add(newAddress);
            newAddress.PropertyChanged += NewAddress_PropertyChanged;

            if (CreatePersonCommand != null)
                CreatePersonCommand.RaiseCanExecuteChanged();
        }

      

        private void AddPhoneNumber()
        {
            PhoneConnection phoneConnection = new PhoneConnection { PhoneNumber = String.Empty };
            PhoneConnections.Add(phoneConnection);
            phoneConnection.PropertyChanged += PhoneConnection_PropertyChanged;

            if (CreatePersonCommand != null)
                CreatePersonCommand.RaiseCanExecuteChanged();

        }

        private void NewAddress_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CreatePersonCommand != null)
                CreatePersonCommand.RaiseCanExecuteChanged();
        }

        private void PhoneConnection_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CreatePersonCommand != null)
                CreatePersonCommand.RaiseCanExecuteChanged();
        }

        private bool CanCreatePerson()
        {
           
            if (!IsNameDataValid(Name,FirstName) || DateOfBirth == null)
            {
                return false;
            }

            foreach (Address address in Addresses)
            {
                if ((address.Street == string.Empty) ||
                    (address.ZipCode == string.Empty) ||
                    (address.City == string.Empty) ||
                    (address.HouseNumber == string.Empty) || !PersonDataValidator.IsZipCodeValid(address.ZipCode))
                {
                    
                    return false;
                }
            }

            foreach (PhoneConnection phoneConnection in PhoneConnections)
            {
                if ((phoneConnection.PhoneNumber == string.Empty) && !PersonDataValidator.IsPhoneNumberValid(phoneConnection.PhoneNumber))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNameDataValid(string name, string firstName)
        {
            bool returnValue = false;
            if (name != String.Empty && firstName != String.Empty)
            {
                returnValue = true;
            }

            return returnValue;
        }

        private async void CreatePerson()
        {
            Person personToCreate = new Person
            {
                Name = this.Name,
                FirstName = this.FirstName,
                DateOfBirth = DateOnly.FromDateTime(this.DateOfBirth.Value),
                Addresses = this.Addresses.ToList(),
                PhoneConnections = this.PhoneConnections.ToList()
            };
            await _personService.CreatePersonAsync(personToCreate);
        }

        #endregion
    }
}
