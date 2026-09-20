using Newtonsoft.Json;
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

        public async Task<List<Person>> GetPersonsAsync()
        {
            List<Person> listOfPersons = new List<Person>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/person");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    if (json != null)
                    {
                        listOfPersons = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();
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

        public async Task<Person?> UpdatePersonAsync(Person personToUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/person/{personToUpdate.Id}", personToUpdate);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Person>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
    }
}
