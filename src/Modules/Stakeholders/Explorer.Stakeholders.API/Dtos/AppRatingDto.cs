using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class AppRatingDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
