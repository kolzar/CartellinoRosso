using CartellinoRosso.Models;

namespace CartellinoRosso.Core.Interface
{
    public interface IPlayerService
    {
        Player GeneratePlayer();
        List<Player> GenerateSquad();
    }
}
