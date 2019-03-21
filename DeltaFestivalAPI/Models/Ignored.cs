using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaFestivalAPI.Models
{
    [NotMapped]
    public class Ignored
    {
        public int IdCurrentUser { get; set; }
        public int IdIgnored { get; set; }
    }
}