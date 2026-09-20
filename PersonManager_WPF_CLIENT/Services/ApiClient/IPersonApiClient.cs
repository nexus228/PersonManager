using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.Services.ApiClient
{
    internal interface IPersonApiClient
    {
        Task<Person?> UpdatePersonAsync(Person personToUpdate);

        Task<List<Person>> GetPersonsAsync();
    }
}
