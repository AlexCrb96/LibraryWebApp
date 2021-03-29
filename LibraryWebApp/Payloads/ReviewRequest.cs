using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebApp.Entities
{
    public class ReviewRequest 
    {
        private int rating;
        private string review;
        private Guid bookId;

        public ReviewRequest(int rating, string review, Guid bookId)
        {
            this.rating = rating;
            this.review = review;
            this.bookId = bookId;
        }

        public ReviewRequest()
        {

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
