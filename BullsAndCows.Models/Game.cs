using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Models
{
    public class Game
    {
        public Game()
        {
            this.AIGuesses = new List<AIGuess>();
            this.UserGuesses = new List<UserGuess>();
        }
        public int Id { get; set; }
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
        public ICollection<AIGuess> AIGuesses { get; set; }
        public ICollection<UserGuess> UserGuesses { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
