namespace LibraryWebApp.Entities
{
    public class AuthorRequest 
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public AuthorRequest(string name)
        {
            this.name = name;
        }

        public AuthorRequest()
        {
        
        }

    }
}
