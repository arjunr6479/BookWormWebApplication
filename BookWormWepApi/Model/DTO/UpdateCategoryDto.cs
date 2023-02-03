using BookWormWebAPP.Model.Domain;

namespace BookWormWebApp.Model.DTO
{
    public class UpdateCategoryDto
    {
        public int CatId { get; set; }
        public string CategoryType { get; set; }

        public ICollection<BookDetails> books { get; set; }
    }
}
