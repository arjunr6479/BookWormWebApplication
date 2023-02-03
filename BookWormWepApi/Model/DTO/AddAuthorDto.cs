using BookWormWebAPP.Model.Domain;

namespace BookWormWebApp.Model.DTO
{
    public class AddAuthorDto
    {
        public string AuthorName { get; set; }

        public ICollection<BookDetails> books { get; set; }
    }
}
