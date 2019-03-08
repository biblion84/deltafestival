using System;
using System.Collections.Generic;

namespace DeltaFestivalAPI.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string TicketCode { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public int MoodId { get; set; }
        public MoodDTO ActualMood { get; set; }
        public List<PublicationDTO> Publications { get; set; }
    }
}
