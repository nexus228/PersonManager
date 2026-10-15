using PersonManager_WPF_CLIENT.DTO;
using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.Services.ApiClient
{
    internal interface IPersonApiClient
    {

        Task<PersonDTO?> CreatePersonAsync(PersonDTO personToCreateDTO);

        Task<PersonDTO?> UpdatePersonAsync(int idToUpdate, PersonDTO personToUpdate);

        Task<bool> DeletePersonAsync(int idToDelete);

        Task<List<PersonDTO>> GetPersonsAsync();
    }
}
