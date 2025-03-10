﻿using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using HamsterWarz.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Client.Services
{
    public interface IRequestService
    {
        Task AddNewHamster(HamsterViewModel hamster);
        Task DeleteHamsterRequest(int id);
        Task<IEnumerable<Hamster>> GetAllHamstersAsync();
        Task<IEnumerable<Hamster>> GetRandomCompetitors();
        Task VoteHamster(IEnumerable<Hamster> hamsters, int winnerId);
        Task<IEnumerable<Hamster>> GetTopFiveCompetitors();
        Task<IEnumerable<Hamster>> GetBottomFiveCompetitors();
        Task RegisterMatchData(IEnumerable<Hamster> hamster, int id);
        Task<IEnumerable<Hamster>> GetHamsterMatchData(int id);
        Task<IEnumerable<MatchResultDTO>> GetAllRegisteredMatches();
        Task DeleteMatchRow(int id);
    }
}
