using Newtonsoft.Json;
using PersonManager_WPF_CLIENT.DTO;
using PersonManager_WPF_CLIENT.Model;
using System.Net.Http;
using System.Net.Http.Json;


namespace PersonManager_WPF_CLIENT.Services.ApiClient
{
    internal class PersonApiClient : IPersonApiClient
    {
        private readonly HttpClient _httpClient;

        public PersonApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<PersonDTO>> GetPersonsAsync()
        {
            List<PersonDTO> listOfPersons = new List<PersonDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/person");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    if (json != null)
                    {
                        listOfPersons = JsonConvert.DeserializeObject<List<PersonDTO>>(json) ?? new List<PersonDTO>();
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return listOfPersons;
        }

        public async Task<PersonDTO?> UpdatePersonAsync(int idToUpdate, PersonDTO personToUpdateDTO)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/person/{idToUpdate}", personToUpdateDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PersonDTO>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
        public async Task<PersonDTO?> CreatePersonAsync(PersonDTO personToCreateDTO)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/person", personToCreateDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PersonDTO>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }


        public async Task<bool> DeletePersonAsync(int idToDelete)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/person/{idToDelete}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return false;
        }

       
    }
}
