using PersonManager_WPF_CLIENT.CustomEventArgs;
using PersonManager_WPF_CLIENT.Model;


namespace PersonManager_WPF_CLIENT.Services
{
    internal interface IPersonService
    {
        event EventHandler<PersonChangedEventArgs>? PersonChanged;

        Task UpdatePersonAsync(Person personToUpdate);

        Task DeletePersonAsync(Person personToDelete);

        Task CreatePersonAsync(Person personToCreate);

        Task<List<Person>> GetAllPersonsAsync();
    }
}
