using CartellinoRosso.Core.Interface;
using CartellinoRosso.Models;
using CartellinoRosso.Models.Enum;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CartellinoRosso.Core
{
    public class StaffService : IStaffService
    {
        private static IConfiguration _config;
        private static INameService _nameService;
        private readonly Random _random;

        public StaffService(IConfiguration config, INameService nameService)
        {
            _config = config;
            _nameService = nameService;
            _random = new Random(); 
        }

        public Staff GenerateStaff()
        {
            string firstName = _nameService.ExtractRandomFirstName();
            string lastName = _nameService.ExtractRandomLastName();
            int age = new Random().Next(36, 80);
            StaffRoles staffRoles = GetRandomRole();
            StaffSkills staffSkills = GetRandomStaffSkills();

            return new Staff
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                StaffRoles = staffRoles,
                StaffSkills = staffSkills
            };
        }

        public List<Staff> GenerateSquad() {
            List<Staff> staffs = new List<Staff>();

            for (int i = 0; i <= new Random().Next(2, 4); i++)
            {
                string firstName = _nameService.ExtractRandomFirstName();
                string lastName = _nameService.ExtractRandomLastName();
                int age = new Random().Next(36, 80);
                StaffRoles staffRoles = GetRandomRole();
                StaffSkills staffSkills = GetRandomStaffSkills();
                staffs.Add(new Staff
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    StaffRoles = staffRoles,
                    StaffSkills = staffSkills
                });
            }
            return staffs;
        } 


        private StaffRoles GetRandomRole()
        {
            Array roles = Enum.GetValues(typeof(StaffRoles));
            return (StaffRoles)roles.GetValue(_random.Next(roles.Length));
        }
        private StaffSkills GetRandomStaffSkills()
        {
            Array roles = Enum.GetValues(typeof(StaffSkills));
            return (StaffSkills)roles.GetValue(_random.Next(roles.Length));
        }
    }

}
