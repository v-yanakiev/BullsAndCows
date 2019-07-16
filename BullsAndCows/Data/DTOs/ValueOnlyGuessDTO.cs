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
        [RegularExpression(@"^(?!.*(.).*\1)\d{4}$")]
        public string Value { get; set; }
    }
}
