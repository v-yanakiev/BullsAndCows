using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class TopPlayersDTO
    {
        public ICollection<PlayerDTO> Players { get; set; }
    }
}
