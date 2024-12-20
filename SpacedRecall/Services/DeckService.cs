using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpacedRecall.Models;

namespace SpacedRecall.Services
{
    public class DeckService
    {
        private readonly HttpClient _httpClient;

        public DeckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Deck>> GetDecksAsync()
        {
            var url = "api/Decks";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStreamAsync();
                //return await JsonSerializer.DeserializeAsync<IEnumerable<Deck>>(responseStream);
                return JsonSerializer.Deserialize<List<Deck>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new HttpRequestException($"Request to {url} failed with status code {response.StatusCode}");

            }

        }
    }
}

