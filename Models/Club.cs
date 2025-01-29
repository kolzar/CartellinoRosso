namespace CartellinoRosso.Models
{
    public class Club
    {
        public string Name { get; set; }
        public int Balanced { get; set; }
        public int Budget { get; set; }
        public List<Player> Squad { get; set; } = new List<Player>();
        public List<Staff> Staff { get; set; } = new List<Staff>();
        public string Stadium { get; set; }
        public int Reputation { get; set; }

    }
}
