namespace LibraryWebApp.Entities
{
    public class AuthorBooks
    {
        private int authorId;
        private int bookId;

        public AuthorBooks(int authorId, int bookId)
        {
            this.authorId = authorId;
            this.bookId = bookId;
        }

        public AuthorBooks()
        {

        }

        public int AuthorId { get => authorId; set => authorId = value; }
        public int BookId { get => bookId; set => bookId = value; }
    }
}