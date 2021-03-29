using LibraryWebApp.Entities;
using LibraryWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public class ReviewService
    {
        private RatingAndReviewRepository reviewRepo = new RatingAndReviewRepository();

        public List<ReviewResponse> GetAllReviewsByInsb(Guid insb)
        {
            return reviewRepo.SelectAllReviewsByBookInsb(insb).ConvertAll<ReviewResponse>(review => new ReviewResponse(review.Id, review.Rating, review.Review, review.BookId));
        }

        public IEnumerable<ReviewResponse> GetAllReviews()
        {
            return reviewRepo.SelectAllReviews().ConvertAll<ReviewResponse>(review => new ReviewResponse(review.Id, review.Rating, review.Review, review.BookId));
        }

        public ReviewResponse GetReviewById(int id)
        {
            RatingAndReview review = reviewRepo.SelectReviewById(id);
            return new ReviewResponse(review.Id, review.Rating, review.Review, review.BookId);
        }

        public void SaveReview( ReviewRequest reviewRequest)
        {
            RatingAndReview review = new RatingAndReview(reviewRequest.Rating, reviewRequest.Review, reviewRequest.BookId);
            reviewRepo.AddReview(review);
        }

        public void UpdateReview(int id, ReviewRequest reviewRequest)
        {
           RatingAndReview review = new RatingAndReview(id, reviewRequest.Rating, reviewRequest.Review, reviewRequest.BookId);
           reviewRepo.UpdateReview(id, review);
        }

        public void DeleteReview(int id)
        {
            reviewRepo.RemoveReview(id);
        }

    }
}
