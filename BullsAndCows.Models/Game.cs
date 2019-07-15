using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Models
{
    public class Game
    {
        public Game()
        {
            this.Guesses = new List<Guess>();
        }
        public string Id { get; set; }
        public bool IsActive
        {
            get
            {
                return (!(WonByUser || WonByAI));
            }
        }
        public bool WonByUser { get; set; }
        public bool WonByAI { get; set; }
        public string NumberWhichAIMustGuess { get; set; }
        public string NumberWhichUserMustGuess { get; set; }
        public ICollection<Guess> Guesses { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
