using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Entities
{
    public class AuthorResponse 
    {
        private int id;
        private string name;
        private List<BookResponse> books;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<BookResponse> Books { get => books; set => books = value; }

        public AuthorResponse(int id, string name, List<BookResponse> books)
        {
            this.id = id;
            this.name = name;
            this.books = books;
        }

        public AuthorResponse()
        {

        }

    }
}
