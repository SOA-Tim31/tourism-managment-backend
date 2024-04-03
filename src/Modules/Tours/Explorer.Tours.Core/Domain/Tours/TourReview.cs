using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class TourReview : Entity
    {
        public double Grade { get; init; }
        public string Comment { get; init; }
        public int TouristId { get; init; }
        public DateTime AttendanceDate { get; init; }
        public DateTime ReviewDate { get; init; }

        public long TourId { get; init; }

        public Tour? Tour { get; init; }
        public TourReview(double grade, string comment, int touristId, DateTime attendanceDate, DateTime reviewDate, long tourId)
        {
            Grade = grade;
            Comment = comment;
            TouristId = touristId;
            AttendanceDate = attendanceDate;
            ReviewDate = reviewDate;
            TourId = tourId;

            Validate();
        }

        private void Validate()
        {

            if (Grade < 1 | Grade > 5) throw new ArgumentException("Invalid Grade");
        }

        public TourReview(){ }
    }
}
