using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebApp.Entities
{
    public class ReviewResponse 
    {
        private int id;
        private int rating;
        private string review;
        private Guid bookId;

        public ReviewResponse(int id, int rating, string review, Guid bookId)
        {
            this.id = id;
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
