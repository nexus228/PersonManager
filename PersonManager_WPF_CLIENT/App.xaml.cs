using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services;
using PersonManager_WPF_CLIENT.Services.ApiClient;
using PersonManager_WPF_CLIENT.View;
using PersonManager_WPF_CLIENT.ViewModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace PersonManager_WPF_CLIENT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IPersonService _personService;

        private MainWindowViewModel _mainWindowViewModel;

        public App()
        {
            IPersonApiClient apiClient = _initPersonApiClient();
            _personService = new PersonService(apiClient);
        }

        private IPersonApiClient _initPersonApiClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5282");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return new PersonApiClient(httpClient);
        }


        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _mainWindowViewModel = new MainWindowViewModel(_personService);
            _mainWindowViewModel.ShowDetailsViewRequested += MainWindowViewModel_ShowDetailsViewRequested;
            _mainWindowViewModel.ShowEditViewRequested += MainWindowViewModel_ShowEditViewRequested;


            MainWindow mainWindow = new MainWindow()
            {
                Height = SystemParameters.PrimaryScreenHeight * 0.5,
                Width = SystemParameters.PrimaryScreenWidth * 0.5,
                DataContext = _mainWindowViewModel
            };
            mainWindow.Show();
        }

        private void MainWindowViewModel_ShowDetailsViewRequested(object? sender, Person personToShow)
        {
            DetailsWindow detailsWindow = new DetailsWindow()
            {
                Height = SystemParameters.PrimaryScreenHeight * 0.2,
                Width = SystemParameters.PrimaryScreenWidth * 0.2,
                DataContext = new DetailsWindowViewModel(personToShow)
            };

            detailsWindow.ShowDialog();


        }

        private void MainWindowViewModel_ShowEditViewRequested(object? sender, Person e)
        {
            MessageBox.Show($"Edit requested for: {e.Name} {e.FirstName}, Date of Birth: {e.DateOfBirth?.ToString("d")}");   
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            // Dispose of any resources if necessary
            _mainWindowViewModel.ShowDetailsViewRequested -= MainWindowViewModel_ShowDetailsViewRequested;
            _mainWindowViewModel.ShowEditViewRequested -= MainWindowViewModel_ShowEditViewRequested;
            _mainWindowViewModel.Dispose();
        }

    }
}
