using System.ComponentModel.DataAnnotations;

namespace UserApi.Model.Domain
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
