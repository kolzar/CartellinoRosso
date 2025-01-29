using CartellinoRosso.Core.Interface;
using CartellinoRosso.Models;
using CartellinoRosso.Models.Enum;
using Microsoft.Extensions.Configuration;

namespace CartellinoRosso.Core
{
    public class PlayerService : IPlayerService
    {
        private static IConfiguration _config;
        private static INameService _nameService;

        public PlayerService(IConfiguration config, INameService nameService)
        {
            _config = config;
            _nameService = nameService;
        }

        public Player GeneratePlayer()
        {
            string firstName = _nameService.ExtractRandomFirstName();
            string lastName = _nameService.ExtractRandomLastName();
            Roles role = GetRandomRole();
            int age = new Random().Next(15, 40); 
            int skill = new Random().Next(0, 80);
            int potential = skill + new Random().Next(1, 20);
            int value = CalculateValue(skill, potential);

            return new Player
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Role = role,
                Skill = skill,
                Potential = potential,
                Value = value
            };
        }
        
        public List<Player> GenerateSquad()
        {
            List<Player> squad = new List<Player>();
            for (int i = 0; i <= new Random().Next(2,4); i++) {
                string firstName = _nameService.ExtractRandomFirstName();
                string lastName = _nameService.ExtractRandomLastName();
                int age = new Random().Next(15, 40); 
                int skill = new Random().Next(0, 80);
                int potential = skill + new Random().Next(1, 20);
                int value = CalculateValue(skill, potential);

                squad.Add(new Player
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Role = Roles.Goalkeeper,
                    Skill = skill,
                    Potential = potential,
                    Value = value
                });
            }
            
            for (int i = 0; i <= new Random().Next(4, 9); i++) {
                string firstName = _nameService.ExtractRandomFirstName();
                string lastName = _nameService.ExtractRandomLastName();
                int age = new Random().Next(15, 40);
                int skill = new Random().Next(0, 80);
                int potential = skill + new Random().Next(1, 20);
                int value = CalculateValue(skill, potential);

                squad.Add(new Player
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Role = Roles.Defender,
                    Skill = skill,
                    Potential = potential,
                    Value = value
                });
            }
            
            for (int i = 0; i <= new Random().Next(4, 9); i++) {
                string firstName = _nameService.ExtractRandomFirstName();
                string lastName = _nameService.ExtractRandomLastName();
                int age = new Random().Next(15, 40);
                int skill = new Random().Next(0, 80);
                int potential = skill + new Random().Next(1, 20);
                int value = CalculateValue(skill, potential);

                squad.Add(new Player
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Role = Roles.Midfielder,
                    Skill = skill,
                    Potential = potential,
                    Value = value
                });
            }
            
            for (int i = 0; i <= new Random().Next(2, 7); i++) {
                string firstName = _nameService.ExtractRandomFirstName();
                string lastName = _nameService.ExtractRandomLastName();
                int age = new Random().Next(15, 40);
                int skill = new Random().Next(0, 80);
                int potential = skill + new Random().Next(1, 20);
                int value = CalculateValue(skill, potential);

                squad.Add(new Player
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Role = Roles.Forward,
                    Skill = skill,
                    Potential = potential,
                    Value = value
                });
            }


            return squad;
        }

        public static Roles GetRandomRole()
        {
            Array roles = Enum.GetValues(typeof(Roles));
            Random random = new Random();
            int randomIndex = random.Next(roles.Length);
            return (Roles)roles.GetValue(randomIndex);
        }

        private int CalculateValue(int skill, int potential)
        {
            return skill * 100 + (potential - skill) * 50;
        }
    }

}
