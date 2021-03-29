using LibraryWebApp.Entities;
using LibraryWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public class AuthorService
    {
        private AuthorRepository authorRepository = new AuthorRepository();
        private BookRepository bookRepository = new BookRepository();

        public IEnumerable<AuthorResponse> GetAllAuthors()
        {
            return authorRepository.SelectAllAuthors().ConvertAll<AuthorResponse>(author =>
            {
                List<BookResponse> bookList = bookRepository.SelectBooksByAuthor(author.Id).ConvertAll<BookResponse>(book => new BookResponse(book.Insb, book.Title, book.Authors, book.CreationDate, book.NumberOfPages, book.Reviews, book.Price, book.StockAvailable));
                return new AuthorResponse(author.Id, author.Name, bookList);
            });
        }

        public AuthorResponse GetAuthorById(int id)
        {
            Author author = authorRepository.SelectAuthorById(id);
            List<BookResponse> bookList = bookRepository.SelectBooksByAuthor(author.Id).ConvertAll<BookResponse>(book => new BookResponse(book.Insb, book.Title, book.Authors, book.CreationDate, book.NumberOfPages, book.Reviews, book.Price, book.StockAvailable));
            return new AuthorResponse(author.Id, author.Name, bookList);
        }

        public List<AuthorResponse> GetAuthorsByBookInsb(Guid insb)
        {
            List<Author> authorList = authorRepository.SelectAuthorByBookInsb(insb);
            return authorList.ConvertAll<AuthorResponse>(author => new AuthorResponse(author.Id, author.Name, author.Books));
        }

        public void UpdateAuthor(int authorId, AuthorRequest authorRequest)
        {
            Author author = new Author(authorId, authorRequest.Name);
            authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(int authorId)
        {
            authorRepository.RemoveAuthor(authorId);
        }

        public void SaveAuthor(AuthorRequest authorRequest)
        {
            Author author = new Author(authorRequest.Name);
            authorRepository.AddAuthor(author);
        }
    }
}
