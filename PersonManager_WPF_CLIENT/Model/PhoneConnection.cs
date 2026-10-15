using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonManager_WPF_CLIENT.Model
{
    internal class PhoneConnection : INotifyPropertyChanged
    {
        private string _phoneNumber = string.Empty;

        public int Id { get; set; }

        public required string PhoneNumber 
        {
            get 
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
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
