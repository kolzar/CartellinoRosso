namespace CartellinoRosso.Models
{
    public class League
    {
        public string Name { get; set; }
        public List<Club> Teams { get; set; } = new List<Club>();
        public List<(Club, Club)> Schedule { get; private set; } = new List<(Club, Club)>();
    }
}
