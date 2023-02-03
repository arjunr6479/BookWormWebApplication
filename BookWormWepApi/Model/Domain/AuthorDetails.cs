using BookWormWepApi.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace BookWormWebAPP.Model.Domain
{
    public class AuthorDetails
    {
        [Key]
        public int AuthId { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public ICollection<BookDetails> books { get; set; }
    }
}

