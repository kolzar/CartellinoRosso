using CartellinoRosso.Models.Enum;

namespace CartellinoRosso.Models
{
    public class Staff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public StaffRoles StaffRoles { get; set; }
        public StaffSkills StaffSkills { get; set; }
    }
}
