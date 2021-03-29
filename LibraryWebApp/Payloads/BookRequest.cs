using System;
using System.Collections.Generic;

namespace LibraryWebApp.Entities
{
    public class BookRequest
    {
        private string title;
        private DateTime creationDate;
        private int numberOfPages;
        private double price; 
        private int stockAvailable;
        private List<int> authorIds;

        public string Title
        {
            get => title;
            set => title = value;
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
        public List<int> AuthorIds { get => authorIds; set => authorIds = value; }

        public BookRequest(string title, int year, int month, int day, int nOP, double price, int stockAvailable) : this(title,
            new DateTime(year, month, day), nOP, price, stockAvailable){}


        public BookRequest(string title, DateTime creationDate, int numberOfPages,
           double price, int stockAvailable)
        {
            this.title = title;
            this.creationDate = creationDate;
            this.numberOfPages = numberOfPages;
            this.price = price;
            this.stockAvailable = stockAvailable;
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