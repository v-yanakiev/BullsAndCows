using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Score { get { return this.Games.Count(a=>a.WonByUser); } }
        public double PercentageWins { get { return ((100.0*this.Score) / this.Games.Count); } }
    }
}
