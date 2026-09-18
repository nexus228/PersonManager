using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.Services.ApiClient
{
    internal interface IPersonApiClient
    {
        Task<List<Person>> GetPersonsAsync();
    }
}
