namespace CartellinoRosso.Models
{
    public class Match
    {
        public Club TeamA { get; set; }
        public Club TeamB { get; set; }
        public (int, int) Result { get; set; } = (0, 0);
        public List<string> Events { get; set; } = new List<string>();
    }
}
