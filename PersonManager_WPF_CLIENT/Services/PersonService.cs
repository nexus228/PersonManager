using PersonManager_WPF_CLIENT.CustomEventArgs;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services.ApiClient;


namespace PersonManager_WPF_CLIENT.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonApiClient _apiClient;

        public event EventHandler<PersonChangedEventArgs>? PersonChanged;


        public PersonService(IPersonApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task<List<Person>> GetAllPersonsAsync()
        {
            List<Person> persons = await _apiClient.GetPersonsAsync();
            return persons;
        }

        public async Task UpdatePersonAsync(Person personToUpdate)
        {
            Person? updatedPerson = await _apiClient.UpdatePersonAsync(personToUpdate);

            if (updatedPerson != null)
            {
                PersonChanged?.Invoke(this, new PersonChangedEventArgs(updatedPerson));
            }
        }
    }
}
