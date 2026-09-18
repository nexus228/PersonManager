using Newtonsoft.Json;
using PersonManager_WPF_CLIENT.Model;
using System.Net.Http;


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
            HttpResponseMessage response = await _httpClient.GetAsync("api/person");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                if (json != null)
                {
                    listOfPersons = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();      
                }
                 
            }
            return listOfPersons;
        }
    }
}
