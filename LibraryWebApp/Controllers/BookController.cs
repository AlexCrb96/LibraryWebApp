using LibraryWebApp.Entities;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService bookService = new BookService();

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<BookResponse> Get()
        {
            return bookService.GetAllBooks();
        }

        // GET api/<BookController>/5
        [HttpGet("{insb}")]
        public BookResponse Get(Guid insb)
        {
            return bookService.GetBookByInsb(insb);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] BookRequest bookRequest)
        {
            bookService.SaveBook(bookRequest);
        }

        // PUT api/<BookController>/5
        [HttpPut("{insb}")]
        public void Put(Guid insb, [FromBody] BookRequest bookRequest)
        {
            bookService.UpdateBook(insb, bookRequest);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{insb}")]
        public void Delete(Guid insb)
        {
            bookService.DeleteBook(insb);
        }
    }
}
