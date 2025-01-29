using CartellinoRosso.Core.Interface;
using CartellinoRosso.Models;
using Microsoft.Extensions.Configuration;

namespace CartellinoRosso.Core
{
    public class ClubService : IClubService
    {

        private static IConfiguration _config;
        private static INameService _nameService;
        private static IPlayerService _playerService;
        private static IStaffService _staffService;

        public ClubService(IConfiguration config, 
            INameService nameService, 
            IPlayerService playerService,
            IStaffService staffService)
        {
            _config = config;
            _nameService = nameService;
            _playerService = playerService;
            _staffService = staffService;
        }

        public Club GenerateClub()
        {
            string name = _nameService.ExtractRandomTeamList();
            int balanced = GenerateRandomBalanced();
            int budget = GenerateRandomBudget();
            int reputation = GenerateRandomReputation();
            var squad = _playerService.GenerateSquad();
            var staff = _staffService.GenerateSquad();

            return new Club
            {
                Name = name,
                Balanced = balanced,
                Budget = budget,
                Squad = squad,
                Staff = staff,
                Reputation = reputation,
            };
        }

        private int GenerateRandomBalanced()
        {
            Random random = new Random();
            return random.Next(1000000, 100000000); // Budget casuale tra 1M e 10M
        }
        
        private int GenerateRandomBudget()
        {
            Random random = new Random();
            return random.Next(1000000, 100000000); // Budget casuale tra 1M e 10M
        }

        private int GenerateRandomReputation()
        {
            Random random = new Random();
            return random.Next(1, 100); // Reputazione casuale tra 1 e 100
        }
    }
}
