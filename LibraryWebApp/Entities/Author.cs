using System.Collections.Generic;

namespace LibraryWebApp.Entities
{
    public class Author 
    {
        private int id;
        private string name;
        private List<BookResponse> books;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<BookResponse> Books { get => books; set => books = value; }

        public Author(int id, string name, List<BookResponse> books) : this(id, name)
        {
            this.books = books;
        }

        public Author(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Author(string name)
        {
            this.name = name;
        }
        public Author()
        {
        }

    }
}
