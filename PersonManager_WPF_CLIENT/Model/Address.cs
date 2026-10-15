using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PersonManager_WPF_CLIENT.Model
{
    internal class Address : INotifyPropertyChanged
    {
        private string _street = string.Empty;
        private string _houseNumber = string.Empty;
        private string _zipCode = string.Empty;
        private string _city = string.Empty;


        public int Id { get; set; }
        public required string Street 
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged();
            }
        }

        public required string HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                _houseNumber = value;
                OnPropertyChanged();
            }
        }

        public required string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }

        public required string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
