using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class BookRequest
    {
        [Required]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public int NumberOfPages { get; set; }

        public int StockAvailable { get; set; }
        public double Price { get; set; }
        [Required]
        public List<int> AuthorIds { get; set; }

        public BookRequest(string title, int year, int month, int day, int nOP, double price, int stockAvailable) : this(title,
            new DateTime(year, month, day), nOP, price, stockAvailable){}


        public BookRequest(string title, DateTime creationDate, int numberOfPages,
           double price, int stockAvailable)
        {
            this.Title = title;
            this.CreationDate = creationDate;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
            this.StockAvailable = stockAvailable;
        }

        public BookRequest()
        {

        }

        public void Print()
        {
            Console.WriteLine(
                $"Title: {Title}  \nCreationDate: {CreationDate} \nNumber of pages: {NumberOfPages} \n");
        }

    }
}