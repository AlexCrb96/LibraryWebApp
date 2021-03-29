using System;
using System.Collections.Generic;

namespace LibraryWebApp.Entities
{
    public class BookResponse
    {
        private Guid insb;
        private string title;
        private List<AuthorResponse> authors; 
        private DateTime creationDate;
        private int numberOfPages;
        private List<ReviewResponse> reviews; 
        private double price; 
        private int stockAvailable; 

        public Guid Insb
        {
            get => insb;
            set => insb = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public List<AuthorResponse> Authors
        {
            get => authors;
            set => authors = value;
        }
        public DateTime CreationDate
        {
            get => creationDate;
            set => creationDate = value;
        }

        public int NumberOfPages
        {
            get => numberOfPages;
            set => numberOfPages = value;
        }

        public List<ReviewResponse> Reviews
        {
            get => reviews;
            set => reviews = value;
        }

        public int StockAvailable 
        { 
            get => stockAvailable; 
            set => stockAvailable = value;
        }
        public double Price 
        {
            get => price;
            set => price = value; 
        }

        public BookResponse(string title, List<Author> author, int year, int month, int day, int nOP, List<RatingAndReview> rAR, double price, int stockAvailable) : this(Guid.NewGuid(), title, author,
            new DateTime(year, month, day), nOP, rAR, price, stockAvailable){}


        public BookResponse(Guid insb, string title, List<Author> authors, DateTime creationDate, int numberOfPages,
            List<RatingAndReview> ratingAndReviews, double price, int stockAvailable)
        {
            this.insb = insb;
            this.title = title;
            this.authors = authors.ConvertAll<AuthorResponse>(author => new AuthorResponse(author.Id, author.Name, author.Books));
            this.creationDate = creationDate;
            this.numberOfPages = numberOfPages;
            this.reviews = ratingAndReviews.ConvertAll<ReviewResponse>(review => new ReviewResponse(review.Id, review.Rating, review.Review, review.BookId));
            this.price = price;
            this.stockAvailable = stockAvailable;
        }

        public void Print()
        {
            Console.WriteLine(
                $"INSB: {Insb} \nTitle: {Title} \nAuthors: {Authors} \nCreationDate: {CreationDate} \nNumber of pages: {NumberOfPages} \nRating and reviews: {Reviews} \n");
        }

    }
}