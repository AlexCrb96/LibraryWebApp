using System.Collections.Generic;

namespace LibraryWebApp.Entities
{
    public class Author 
    {

        public int Id { get ; set; }
        
        public string Name { get; set; }
        public List<BookResponse> Books { get; set; }

        public Author(int id, string name, List<BookResponse> books) : this(id, name)
        {
            this.Books = books;
        }

        public Author(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Author(string name)
        {
            this.Name = name;
        }
        public Author()
        {
        }

    }
}
