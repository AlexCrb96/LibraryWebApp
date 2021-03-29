using System;
using System.Collections.Generic;

namespace LibraryWebApp.Entities
{
    public class Book
    {
        private Guid insb;
        private string title;
        private List<Author> authors; 
        private DateTime creationDate;
        private int numberOfPages;
        private List<RatingAndReview> reviews; 
        private double price; 
        private int stockAvailable;
        private List<int> authorsId;

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

        public List<Author> Authors
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

        public List<RatingAndReview> Reviews
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
        public List<int> AuthorsId { get => authorsId; set => authorsId = value; }

        public Book(string title, List<Author> author, int year, int month, int day, int nOP, List<RatingAndReview> rAR, double price, int stockAvailable) : this(Guid.NewGuid(), title, author,
            new DateTime(year, month, day), nOP, rAR, price, stockAvailable){}


        public Book(Guid insb, string title, List<Author> authors, DateTime creationDate, int numberOfPages,
            List<RatingAndReview> ratingAndReviews, double price, int stockAvailable)
        {
            this.insb = insb;
            this.title = title;
            this.authors = authors;
            this.creationDate = creationDate;
            this.numberOfPages = numberOfPages;
            this.reviews = ratingAndReviews;
            this.price = price;
            this.stockAvailable = stockAvailable;
        }

        public Book(Guid insb, string title, DateTime creationDate, int numberOfPages, double price, int stockAvailable, List<int> authorsId)
        {
            this.insb = insb;
            this.title = title;
            this.creationDate = creationDate;
            this.numberOfPages = numberOfPages;
            this.price = price;
            this.stockAvailable = stockAvailable;
            this.authorsId = authorsId;
        }


        public void Print()
        {
            Console.WriteLine(
                $"INSB: {Insb} \nTitle: {Title} \nAuthors: {Authors} \nCreationDate: {CreationDate} \nNumber of pages: {NumberOfPages} \nRating and reviews: {Reviews} \n");
        }

    }
}