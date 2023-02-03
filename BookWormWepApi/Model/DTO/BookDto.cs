using BookWormWebAPP.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookWormWebAPP.Model.DTO
{
    public class BookDto
    {
        public int id { get; set; }
        public string BookName { get; set; }

        public Blob ImagePath { get; set; }

        public AuthorDetails authorDetails { get; set; }

        public CategoryDetails categoryDetails { get; set; }

    }
}
