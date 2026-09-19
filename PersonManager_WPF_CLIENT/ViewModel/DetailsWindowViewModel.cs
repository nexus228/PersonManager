using PersonManager_WPF_CLIENT.Model;
using System.Collections.ObjectModel;


namespace PersonManager_WPF_CLIENT.ViewModel
{
    internal class DetailsWindowViewModel : ViewModelBase
    {
        private Person _personToShow;

        public string? DisplayName => _personToShow.Name + ", " + _personToShow.FirstName;

        public ObservableCollection<Address> Addresses
        {
            get;
            private set;
        }

        public ObservableCollection<PhoneConnection> PhoneNumbers
        {
            get;
            private set;
        }

       

        public DetailsWindowViewModel(Person personToShow)
        {
            _personToShow = personToShow;
            if(_personToShow.Addresses != null)
            {
                Addresses = new ObservableCollection<Address>(_personToShow.Addresses);
            }

            if (_personToShow.PhoneConnections != null)
            {
                PhoneNumbers = new ObservableCollection<PhoneConnection>(_personToShow.PhoneConnections);
            }
        }
    }
}
