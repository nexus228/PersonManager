using PersonManager_WPF_CLIENT.Command;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace PersonManager_WPF_CLIENT.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        #region private fields
        private readonly IPersonService _personService;

        private bool _isLoading;

        private ObservableCollection<Person> _personList = new ObservableCollection<Person>();

        private ICollectionView _personCollectionView = CollectionViewSource.GetDefaultView(new ObservableCollection<Person>());

        private string _searchText = string.Empty;

        #endregion

        #region public Properties

        public string SearchText 
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));

                PersonCollectionView.Refresh();
            }
        }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _personList;
            }
            set 
            {
                _personList = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public ICollectionView PersonCollectionView
        {
            get
            {
                return _personCollectionView;
            }
            set
            {
                _personCollectionView = value;
                OnPropertyChanged(nameof(PersonCollectionView));
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

        #endregion

        #region public Commands

        public ICommand LoadPersonsCommand { get; private set; }

        public ICommand ClearListCommand { get; private set; }

        public ICommand ShowPersonDetailsCommand { get; private set; }

        public ICommand EditPersonDataCommand { get; private set; }

        #endregion

        #region public eventHandler

        public event EventHandler<Person>? ShowDetailsViewRequested;

        public event EventHandler<Person>? ShowEditViewRequested;

        #endregion
        public MainWindowViewModel(IPersonService personService)
        {
            _personService = personService;

            Persons.CollectionChanged += Persons_CollectionChanged;

            PersonCollectionView = CollectionViewSource.GetDefaultView(Persons);

            PersonCollectionView.Filter = SearchFilter;

            LoadPersonsCommand = new BaseCommand(async () => await LoadPersonsAsync());
            ClearListCommand = new BaseCommand(() => Persons.Clear(), CanClearList);

            ShowPersonDetailsCommand = new RelayCommand<Person>(async (person) => ShowDetailsViewRequested?.Invoke(this, person));
            EditPersonDataCommand = new RelayCommand<Person>(async (person) => ShowEditViewRequested?.Invoke(this, person));  
        }


        public override void Dispose()
        {
            base.Dispose();
            Persons.CollectionChanged -= Persons_CollectionChanged;
            ShowDetailsViewRequested = null;
            ShowEditViewRequested = null;
        }

        private void Persons_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if(ClearListCommand is BaseCommand clearListCommand)
            {
                clearListCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanClearList()
        {
            return Persons.Count > 0;
        }

        private async Task LoadPersonsAsync()
        {
            IsLoading = true;

            //await _simulateProgessDelay();

            var persons = await _personService.GetAllPersonsAsync();
            
            Persons.Clear();
            foreach (var person in persons)
            {
                Persons.Add(person);
            }

            PersonCollectionView = CollectionViewSource.GetDefaultView(Persons);

            IsLoading = false;
        }

        private async Task ShowDetailsView(Person person)
        {
            
        }

        private bool SearchFilter(object obj)
        {
            bool returnValue = false;

            Person? personToFilter = obj as Person;
            if (personToFilter != null)
            {
                if (!string.IsNullOrEmpty(SearchText) && personToFilter.Name != null && personToFilter.FirstName != null)
                {
                    returnValue = (personToFilter.Name.Contains(SearchText) || personToFilter.FirstName.Contains(SearchText));
                }
                else if(string.IsNullOrWhiteSpace(SearchText))
                {
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private async Task _simulateProgessDelay()
        {

            await Task.Run(async () =>
            {
                await Task.Delay(2000); // Simulate a delay for loading
            });
        }
    }
}
