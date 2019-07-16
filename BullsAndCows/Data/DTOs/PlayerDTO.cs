using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class PlayerDTO
    {
        public PlayerDTO()
        {

        }
        public PlayerDTO(User user)
        {
            this.UserName = user.UserName;
            this.HighScore = user.Score;
            this.PercentageWins = Math.Round(user.PercentageWins, 1);
        }
        public string UserName { get; set; }
        public int HighScore { get; set; }
        public double PercentageWins { get; set; }
    }
}
