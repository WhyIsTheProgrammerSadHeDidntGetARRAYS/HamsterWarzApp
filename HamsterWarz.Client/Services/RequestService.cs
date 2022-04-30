using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using HamsterWarz.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Client.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddNewHamster(HamsterViewModel hamster)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/hamsters", hamster);

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
            //otroligt konstig men fun fact - när man skickar det såhär, och tar emot objektet i sin api endpoint,
            //så behöver properties i det objektet man tar emot heta samma som dessa parameterar som skickas.
            //testa att att ändra detta post objekt's id parameter till winnerId, sätt en breakpoint i hamsterscontroller 
            //vote-endpoint, och kolla på id't som tas emot

            await _httpClient.PostAsJsonAsync("/api/hamsters/vote", new { hamsters, id });
        }

        
        public async Task RegisterMatchData(IEnumerable<Hamster> hamsters, int id)
        {
            await _httpClient.PostAsJsonAsync("/api/matches/registermatch", new { hamsters, id });
        }
        public async Task<IEnumerable<Hamster>> GetTopFiveCompetitors()
        {
            var responseTask = await _httpClient.GetAsync("/api/hamsters/topfive");

            if (responseTask.IsSuccessStatusCode)
            {
                var value = responseTask.Content.ReadFromJsonAsync<IEnumerable<Hamster>>().Result;
                return value!;
            }
            return new List<Hamster>();
        }

        public async Task<IEnumerable<Hamster>> GetBottomFiveCompetitors()
        {
            //TODO: Kika på om det är såhär jag vill göra, med statuscode check
            var responseTask = await _httpClient.GetAsync("/api/hamsters/bottomfive");
            
            if (responseTask.IsSuccessStatusCode)
            {
                var value = responseTask.Content.ReadFromJsonAsync<IEnumerable<Hamster>>().Result;
                return value!;
            }
            return new List<Hamster>();
            //var list = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>("/api/hamsters/bottomfive");
            //return list!;
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

        public async Task DeleteMatchRow(int id)
        {
            //var url = "https://localhost:7026/api/matches/delete";
            await _httpClient.DeleteAsync($"/api/matches/delete/{id}");
        }

        
    }
}
