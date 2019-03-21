using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestivalAPI.Models
{
    public class Publication
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string File { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public bool Like { get; set; }
        public string Hashtag { get; set; }
    }
}
