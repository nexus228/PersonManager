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

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(_personService);

            MainWindow mainWindow = new MainWindow()
            {
                Height = SystemParameters.PrimaryScreenHeight * 0.5,
                Width = SystemParameters.PrimaryScreenWidth * 0.5,
                DataContext = mainWindowViewModel
            };
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            // Dispose of any resources if necessary
        }

    }
}
