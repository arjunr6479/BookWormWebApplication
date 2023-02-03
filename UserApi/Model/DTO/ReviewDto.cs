using System.ComponentModel.DataAnnotations;

namespace UserApi.Model.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
