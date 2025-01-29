using CartellinoRosso.Models.Enum;

namespace CartellinoRosso.Models
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Roles Role { get; set; }
        public int Skill { get; set; }
        public int Potential { get; set; }
        public int Value { get; set; }
        public int Salary { get; set; }
    }
}
