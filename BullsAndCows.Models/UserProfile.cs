using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public ICollection<Game> Games { get; set; }
        public int Rating { get { return 0; } }
    }
}
