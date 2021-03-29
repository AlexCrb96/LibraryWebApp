using LibraryWebApp.Entities;
using LibraryWebApp.Repositories;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorService authorService = new AuthorService();

        // GET: api/<LibraryController>
        [HttpGet]
        public IEnumerable<AuthorResponse> Get()
        {
            return authorService.GetAllAuthors();
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public AuthorResponse Get(int id)
        {
            return authorService.GetAuthorById(id);
        }

        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] AuthorRequest authorRequest)
        {
            authorService.SaveAuthor(authorRequest);
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorRequest authorRequest)
        {
            authorService.UpdateAuthor(id, authorRequest);
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            authorService.DeleteAuthor(id);
        }
    }
}
