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
        [RegularExpression("^[0-9]{4}$")]
        public string Value { get; set; }
    }
}
