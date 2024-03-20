using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourObject : Entity
    {
        public string Name { get; init; }
        
        public int TourId { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public ObjectCategory Category { get; init; }
        public float Latitude { get; init; }
        public float Longitude { get; init; }

        public TourObject(string name,int tourId, string description, string imageUrl, ObjectCategory category, float latitude, float longitude)
        {
            Name = name;
            TourId = tourId;
            Description = description;
            ImageUrl = imageUrl;
            Category = category;
            Latitude = latitude;
            Longitude = longitude;
        }


    }
}
