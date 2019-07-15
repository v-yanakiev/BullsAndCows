namespace BullsAndCows.Models
{
    public class GuessOutcome
    {
        public string Id { get; set; }
        public string GuessId { get; set; }
        public Guess Guess { get; set; }
        public int BullsNumber { get; set; }
        public int CowsNumber { get; set; }
    }
}