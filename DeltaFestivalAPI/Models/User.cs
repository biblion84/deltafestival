using System;
using System.Collections.Generic;

namespace DeltaFestivalAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TicketCode { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int MoodId { get; set; }
        public Mood ActualMood { get; set; }
        public List<Publication> Publications { get; set; }
    }
}
