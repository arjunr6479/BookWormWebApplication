using System.ComponentModel.DataAnnotations;

namespace BookWormWebAPP.Model.Domain
{
    public class CategoryDetails
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string CategoryType { get; set; }

        public ICollection<BookDetails> books { get; set; }

    }
}
