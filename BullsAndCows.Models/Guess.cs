using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BullsAndCows.Models
{
    public enum GuessMaker { AI,User}
    public class Guess
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string GameId { get; set; }
        public Game Game { get; set; }
        public string GuessOutcomeId { get; set; }
        public GuessOutcome GuessOutcome { get; set; }
        [Required]
        public GuessMaker GuessMaker { get; set; }
    }
}
