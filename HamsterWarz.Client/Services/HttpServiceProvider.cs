using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Client.Services
{
    public class HttpServiceProvider : IHttpServiceProvider
    {
        private readonly HttpClient _httpClient;

        public HttpServiceProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Hamster>> GetAllHamstersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>("api/hamsters");
            return response!;
        }

        public async Task<IEnumerable<Hamster>> GetRandomCompetitors()
        {
            //TODO: kanske ska man istället göra filtreringen av datan på client-sidan? Har ju redan en get all från apin, som jag kan filtrera på här
            var content = await _httpClient.GetFromJsonAsync<List<Hamster>>("api/hamsters/random");
            return content!;

        }
        public async Task VoteHamster(IEnumerable<Hamster> hamsters, int id)
        {
            await _httpClient.PostAsJsonAsync("/api/hamsters/vote", new { hamsters, id });
        }

        public async Task<IEnumerable<Hamster>> GetTopFiveCompetitors()
        {
            var list = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>("api/hamsters/topfive");
            return list!;
        }

        public async Task RegisterMatchData(IEnumerable<Hamster> hamsters, int id)
        {
            await _httpClient.PostAsJsonAsync("/api/matches/registermatch", new { hamsters, id });
        }

        public async Task<IEnumerable<Hamster>> GetBottomFiveCompetitors()
        {
            var list = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>("/api/hamsters/bottomfive");
            return list!;
        }

        public async Task<IEnumerable<Hamster>> GetHamsterMatchData(int id)
        {
            var test = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>($"/api/matches/statistics/{id}");
            return test!;
        }

        public async Task<IEnumerable<MatchResultDTO>> GetAllRegisteredMatches()
        {
            var test = await _httpClient.GetFromJsonAsync<IEnumerable<MatchResultDTO>>("/api/matches");
            return test!;

        }
    }
}
