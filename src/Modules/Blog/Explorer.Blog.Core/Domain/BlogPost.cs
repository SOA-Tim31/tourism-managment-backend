using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace Explorer.Blog.Core.Domain
{

    public enum BlogPostStatus { DRAFT, PUBLISHED, CLOSED, ACTIVE, FAMOUS };
    public class BlogPost : Entity
    {
        public int AuthorId { get; init; }
        public int TourId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreationDate { get; init; }
        public string? ImageURLs { get; init; }
        public List<BlogPostComment>? Comments { get; init; }
        public List<BlogPostRating>? Ratings { get; init; }
        public BlogPostStatus Status { get; set; }

        public BlogPost(int authorId,int tourId, string title, string description, DateTime creationDate, string imageURLs, List<BlogPostComment>? comments, BlogPostStatus status, List<BlogPostRating>? ratings)
        {
            if (authorId == 0) throw new ArgumentException("Field required");
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Invalid Title.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid Description.");
            if (creationDate == default) throw new ArgumentException("Invalid Creation Date.");
            if (status != BlogPostStatus.DRAFT && status != BlogPostStatus.PUBLISHED && status != BlogPostStatus.CLOSED && status != BlogPostStatus.ACTIVE && status != BlogPostStatus.FAMOUS)
                throw new ArgumentException("Invalid Post Status");

            AuthorId = authorId;
            TourId = tourId;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            ImageURLs = imageURLs;
            Comments = comments ?? new List<BlogPostComment>();
            Ratings = ratings ?? new List<BlogPostRating>();
            Status = status;
        }

        public void AddComment(BlogPostCommentDto commentDto)
        {
            // Map the DTO to the domain entity
            var Comment = new BlogPostComment(commentDto.Text, commentDto.UserId, DateTime.Now, DateTime.Now);

            // Add the comment to the collection
            Comments.Add(Comment);
            CheckStatusUpdate();
        }

        public void RemoveComment(int userId, DateTime creationTime)
        {
            // Assuming a hypothetical method that identifies and removes the comment based on certain criteria
            var commentToRemove = Comments.FirstOrDefault(c =>
                c.UserId == userId &&
                c.CreationTime.Date == creationTime.Date &&
                c.CreationTime.Hour == creationTime.Hour &&
                c.CreationTime.Minute == creationTime.Minute &&
                c.CreationTime.Second == creationTime.Second);

            if (commentToRemove != null)
            {
                Comments.Remove(commentToRemove);
                CheckStatusUpdate() ;
            }
        }

        public void EditComment(BlogPostCommentDto editedComment)
        {
            // Assuming a hypothetical method that identifies and edits the comment based on certain criteria
            var commentToEdit = Comments.FirstOrDefault(c =>
                c.UserId == editedComment.UserId &&
                c.CreationTime.Equals(editedComment.CreationTime));

            if (commentToEdit != null)
            {
                Comments.Remove(commentToEdit);

                // Add the edited comment to the list
                Comments.Add(new BlogPostComment(editedComment.Text, editedComment.UserId, editedComment.CreationTime, DateTime.Now));
            }
        }
        public void AddRating(BlogPostRatingDto ratingDto)
        {
            var rating = Ratings.FirstOrDefault(c =>
                c.UserId == ratingDto.UserId);

            if (rating != null)
            {
                Ratings.Remove(rating);

                Ratings.Add(new BlogPostRating(ratingDto.UserId, ratingDto.CreationTime,  ratingDto.IsPositive));
                CheckStatusUpdate();
            }
            else
            {
                Ratings.Add(new BlogPostRating(ratingDto.UserId, ratingDto.CreationTime, ratingDto.IsPositive));
                CheckStatusUpdate();
            }

        }
        public void RemoveRating(int userId)
        {
            // Assuming a hypothetical method that identifies and removes the comment based on certain criteria
            var ratingToRemove = Ratings.FirstOrDefault(c =>
                c.UserId == userId);

            if (ratingToRemove != null)
            {
                Ratings.Remove(ratingToRemove);
                CheckStatusUpdate();
            }
        }

        public void CheckStatusUpdate()
        {
            int totalScore = Ratings.Sum(r => r.IsPositive ? 1 : -1);

            if(totalScore < -1)
            {
                Status = BlogPostStatus.CLOSED;
                return;
            }

            if (totalScore > 3 && Comments.Count > 3)
            {
                Status = BlogPostStatus.FAMOUS;
                return;
            }

            if (totalScore > 1 || Comments.Count > 1)
            {
                Status = BlogPostStatus.ACTIVE;
                return;
            }

            Status = BlogPostStatus.PUBLISHED;

            
        }


    }
}
