using PersonManager_WPF_CLIENT.CustomEventArgs;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services;
using PersonManager_WPF_CLIENT.Services.ApiClient;
using PersonManager_WPF_CLIENT.View;
using PersonManager_WPF_CLIENT.ViewModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Xml.Linq;

namespace PersonManager_WPF_CLIENT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IPersonService _personService;

        private MainWindowViewModel _mainWindowViewModel;
        private EditWindow _editWindow;
        private CreatePersonWindow _createPersonWindow;

        public App()
        {
            IPersonApiClient apiClient = _initPersonApiClient();
            _personService = new PersonService(apiClient);
            _personService.PersonChanged += PersonService_PersonChanged;

            _mainWindowViewModel = new MainWindowViewModel(_personService);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _mainWindowViewModel.ShowDetailsViewRequested += MainWindowViewModel_ShowDetailsViewRequested;
            _mainWindowViewModel.ShowEditViewRequested += MainWindowViewModel_ShowEditViewRequested;
            _mainWindowViewModel.ShowDeleteViewRequested += MainWindowViewModel_ShowDeleteViewRequested;
            _mainWindowViewModel.ShowCreateViewRequested += MainWindowViewModel_ShowCreateViewRequested;

            MainWindow mainWindow = new MainWindow()
            {
                Height = SystemParameters.PrimaryScreenHeight * 0.5,
                Width = SystemParameters.PrimaryScreenWidth * 0.5,
                DataContext = _mainWindowViewModel
            };
            mainWindow.Show();
        }

        

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _personService.PersonChanged -= PersonService_PersonChanged;

            // Dispose of any resources if necessary
            _mainWindowViewModel.ShowDetailsViewRequested -= MainWindowViewModel_ShowDetailsViewRequested;
            _mainWindowViewModel.ShowEditViewRequested -= MainWindowViewModel_ShowEditViewRequested;
            _mainWindowViewModel.ShowDeleteViewRequested -= MainWindowViewModel_ShowDeleteViewRequested;
            _mainWindowViewModel.ShowCreateViewRequested -= MainWindowViewModel_ShowCreateViewRequested;

            _mainWindowViewModel.Dispose();
        }


        private void PersonService_PersonChanged(object? sender, PersonChangedEventArgs e)
        {
            if (e.Identfier == PersonChangedEventIdentifier.CREATED || e.Identfier == PersonChangedEventIdentifier.UPDATED)
            {
                if (_createPersonWindow != null && _createPersonWindow.IsActive)
                {
                    _createPersonWindow.Close();
                }
                if (_editWindow != null && _editWindow.IsActive)
                {
                    _editWindow.Close();
                }
            }
        }

        private IPersonApiClient _initPersonApiClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5282");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return new PersonApiClient(httpClient);
        }


        private async void MainWindowViewModel_ShowCreateViewRequested(object? sender, EventArgs e)
        {
            _createPersonWindow = new CreatePersonWindow() 
            {
                Height = 400,
                Width = 700,
                DataContext = new CreatePersonWindowViewModel(_personService)
            };

            _createPersonWindow.ShowDialog();
        
        }

        private async void MainWindowViewModel_ShowDeleteViewRequested(object? sender, Person personToDelete)
        {
            string text = string.Format("Sind Sie sicher, dass Sie {0} {1}-Datensatz löschen möchten?", personToDelete.FirstName, personToDelete.Name);
            MessageBoxResult result = MessageBox.Show(text, "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
               await _personService.DeletePersonAsync(personToDelete);
            }
        }

        private void MainWindowViewModel_ShowDetailsViewRequested(object? sender, Person personToShow)
        {
            DetailsWindow detailsWindow = new DetailsWindow()
            {
                Height = 400,
                Width = 700,
                DataContext = new DetailsWindowViewModel(personToShow)
            };

            detailsWindow.ShowDialog();


        }

        private void MainWindowViewModel_ShowEditViewRequested(object? sender, Person personToEdit)
        {

            if(_editWindow != null)
            {
                _editWindow.Close();
            }

            _editWindow = new EditWindow()
            {
                Height = 400,
                Width = 650,
                DataContext = new EditWindowViewModel(personToEdit, _personService)
            };
            _editWindow.ShowDialog();
        }


    }
}
