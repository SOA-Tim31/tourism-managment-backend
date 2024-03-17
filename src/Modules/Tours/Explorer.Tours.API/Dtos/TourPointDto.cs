using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourPointDto
    {
        public int Id { get; set; }

        public long TourId { get; set; }
        
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string ImageUrl { get; set; }

        public string Secret {  get; set; }
    }
}
