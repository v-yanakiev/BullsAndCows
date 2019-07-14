using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BullsAndCows.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            this.Games = new List<Game>();
        }
        public ICollection<Game> Games { get; set; }
        public int Rating { get { return 0; } }
    }
}
