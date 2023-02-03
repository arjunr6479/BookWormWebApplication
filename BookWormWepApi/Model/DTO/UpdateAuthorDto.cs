using BookWormWebAPP.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace BookWormWebApp.Model.DTO
{
    public class UpdateAuthorDto
    {
        public int AuthId { get; set; }
        public string AuthorName { get; set; }

        public ICollection<BookDetails> books { get; set; }
    }
}
