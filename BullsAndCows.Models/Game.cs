using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Models
{
    public class Game
    {
        public Game()
        {
            this.IsActive = true;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool WonByUser { get; set; }
        public string AINumber { get; set; }
        public string UserNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
