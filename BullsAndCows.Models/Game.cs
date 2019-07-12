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
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
