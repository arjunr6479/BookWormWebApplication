using BookWormWebAPP.Model.Domain;

namespace BookWormWebApp.Model.DTO
{
    public class AddCategoryDto
    {
        public string CategoryType { get; set; }

        public ICollection<BookDetails> books { get; set; }
    }
}
