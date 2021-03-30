using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class AuthorRequest 
    {
        [Required]
        public string Name { get; set; }

        public AuthorRequest(string name)
        {
            this.Name = name;
        }

        public AuthorRequest()
        {
        
        }

    }
}
