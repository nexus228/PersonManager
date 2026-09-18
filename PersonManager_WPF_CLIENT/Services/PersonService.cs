using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services.ApiClient;


namespace PersonManager_WPF_CLIENT.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonApiClient _apiClient;

        public PersonService(IPersonApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            List<Person> persons = await _apiClient.GetPersonsAsync();
            return persons;
        }
    }
}
