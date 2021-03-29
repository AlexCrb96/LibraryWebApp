using LibraryWebApp.Entities;
using LibraryWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public class BookService
    {
        private BookRepository bookRepository = new BookRepository();
        private AuthorRepository authorRepository = new AuthorRepository();
        private RatingAndReviewRepository ratingAndReviewRepository = new RatingAndReviewRepository();

        public IEnumerable<BookResponse> GetAllBooks()
        {
            return bookRepository.SelectAllBooks().ConvertAll<BookResponse>(book => 
            {

                List<Author> authors = authorRepository.SelectAuthorByBookInsb(book.Insb);
                List<RatingAndReview> reviews = ratingAndReviewRepository.SelectAllReviewsByBookInsb(book.Insb);
                return new BookResponse(book.Insb, book.Title, authors, book.CreationDate, book.NumberOfPages, reviews, book.Price, book.StockAvailable);
            });
        }

        public List<BookResponse> GetBooksByAuthor(int authorId)
        {
            return bookRepository.SelectBooksByAuthor(authorId).ConvertAll<BookResponse>(book => new BookResponse(book.Insb, book.Title, book.Authors, book.CreationDate, book.NumberOfPages, book.Reviews, book.Price, book.StockAvailable));
        }

        public BookResponse GetBookByInsb(Guid insb)
        {
            Book book = bookRepository.SelectBookByInsb(insb);
            List<Author> authors = authorRepository.SelectAuthorByBookInsb(insb);
            List<RatingAndReview> reviews = ratingAndReviewRepository.SelectAllReviewsByBookInsb(insb);

            return new BookResponse(book.Insb, book.Title, authors, book.CreationDate, book.NumberOfPages, reviews, book.Price, book.StockAvailable);
        }

        public void DeleteBook(Guid insb)
        {
            bookRepository.RemoveBook(insb);
        }

       public void UpdateBook(Guid insb, BookRequest bookRequest)
        {
            Book book = new Book(insb, bookRequest.Title, bookRequest.CreationDate, bookRequest.NumberOfPages, bookRequest.Price, bookRequest.StockAvailable, bookRequest.AuthorIds);
            bookRepository.UpdateBook(book);
        }

        public void SaveBook(BookRequest bookRequest)
        {
            Book book = new Book(Guid.NewGuid(), bookRequest.Title, bookRequest.CreationDate, bookRequest.NumberOfPages, bookRequest.Price, bookRequest.StockAvailable, bookRequest.AuthorIds);
            bookRepository.AddBook(book);
        }
    }
}
