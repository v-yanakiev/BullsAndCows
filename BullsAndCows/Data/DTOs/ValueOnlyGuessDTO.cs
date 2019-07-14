using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class ValueOnlyGuessDTO
    {
        [Required]
        public string Value { get; set; }
    }
}
