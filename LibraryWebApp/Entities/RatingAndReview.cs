using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebApp.Entities
{
    public class RatingAndReview 
    {
        private int id;
        private int rating;
        private string review;
        private Guid bookId;

        public RatingAndReview(int id, int rating, string review, Guid bookId)
        {
            this.id = id;
            this.rating = rating;
            this.review = review;
            this.bookId = bookId;
        }

        public RatingAndReview(int rating, string review, Guid bookId)
        {
            this.rating = rating;
            this.review = review;
            this.bookId = bookId;
        }

        public int Id 
        {
            get => id;
            set => id = value;
        }
        public int Rating
        {
            get => rating;
            set => rating = value;
        }
        public string Review
        {
            get => review;
            set => review = value;
        }
        public Guid BookId { get => bookId; set => bookId = value; }
    }
}
