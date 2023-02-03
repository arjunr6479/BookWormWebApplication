using BookWormWebAPP.Model.Domain;
using System.Reflection.Metadata;

namespace BookWormWebApp.Model.DTO
{
    public class UpdateBookDto
    {
        public int id { get; set; }
        public string BookName { get; set; }

        public Blob ImagePath { get; set; }


        public AuthorDetails authorDetails { get; set; }

        public CategoryDetails categoryDetails { get; set; }
    }
}
