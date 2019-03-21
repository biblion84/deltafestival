using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaFestivalAPI.Models
{
    [NotMapped]
    public class Crush
    {
        public int IdCurrentUser { get; set; }
        public int IdCrush { get; set; }
    }
}
