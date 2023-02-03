using BookWormWepApi.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookWormWebAPP.Model.Domain
{
    public class BookDetails
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]

        public Blob ImagePath { get; set; }

        //[ForeignKey("AuthId")]
        //[Required]
        //public  int? AuthId { get; set; }
        public AuthorDetails authorDetails { get; set; }

        //[ForeignKey("CatId")]
        //[Required]
        //public int? CatId { get; set; }
        public CategoryDetails categoryDetails { get; set; }
    }
}
