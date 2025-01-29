using CartellinoRosso.Models;

namespace CartellinoRosso.Core.Interface
{
    public interface IStaffService
    {
        List<Staff> GenerateSquad();
        Staff GenerateStaff();
    }
}
