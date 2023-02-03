using BookWormWebAPP.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookWormWebApp.Model.DTO
{
    public class AddBookDto
    {
        public string BookName { get; set; }

        public Blob ImagePath { get; set; }


        public AuthorDetails authorDetails { get; set; }

        public CategoryDetails categoryDetails { get; set; }
    }
}
