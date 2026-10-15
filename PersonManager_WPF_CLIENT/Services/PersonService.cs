using PersonManager_WPF_CLIENT.CustomEventArgs;
using PersonManager_WPF_CLIENT.DTO;
using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.Services.ApiClient;
using PersonManager_WPF_CLIENT.Utils;


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
            List<Person> returnValue = new List<Person>();

            List<PersonDTO> personsDTOs = await _apiClient.GetPersonsAsync();

            foreach (PersonDTO personDTO in personsDTOs)
            {
                Person person = PersonMapper.DTOToPerson(personDTO);
                returnValue.Add(person);
            }

            return returnValue;
        }

        public async Task UpdatePersonAsync(Person personToUpdate)
        {
            PersonDTO personToUpdateDTO = PersonMapper.PersonToDTO(personToUpdate);
            int idToUpdate = personToUpdateDTO.Id;

            PersonDTO? updatedPersonDTO = await _apiClient.UpdatePersonAsync(idToUpdate, personToUpdateDTO);

            if (updatedPersonDTO != null)
            {
                Person updatedPerson = PersonMapper.DTOToPerson(updatedPersonDTO);
                PersonChanged?.Invoke(this, new PersonChangedEventArgs(updatedPerson, PersonChangedEventIdentifier.UPDATED));
            }
        }

        public async Task DeletePersonAsync(Person personToDelete)
        {
            bool isDeleted = await _apiClient.DeletePersonAsync(personToDelete.Id);

            if (isDeleted)
            {
                PersonChanged?.Invoke(this, new PersonChangedEventArgs(personToDelete, PersonChangedEventIdentifier.DELETED));
            }
        }

        public async Task CreatePersonAsync(Person personToCreate)
        {
            PersonDTO personToCreateDTO = PersonMapper.PersonToDTO(personToCreate);

            PersonDTO? createdPersonDTO = await _apiClient.CreatePersonAsync(personToCreateDTO);

            if (createdPersonDTO != null)
            {
                Person createdPerson = PersonMapper.DTOToPerson(createdPersonDTO);
                PersonChanged?.Invoke(this, new PersonChangedEventArgs(createdPerson, PersonChangedEventIdentifier.CREATED));
            }
        }
    }
}
