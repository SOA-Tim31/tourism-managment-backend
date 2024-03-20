using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class TourPoint : Entity
    {
        public long TourId { get; init; }
        public Tour? Tour { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public float Latitude { get; init; }
        public float Longitude { get; init; }
        public string ImageUrl { get; init; }

        public string Secret { get; init; }

        public TourPoint(int idTour, string name, string? description, float latitude, float longitude, string imageUrl, string secret)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            TourId = idTour;
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            ImageUrl = imageUrl;
            Secret = secret;
        }

        public TourPoint() { }
    }
}
