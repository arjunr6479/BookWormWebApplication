using System.ComponentModel.DataAnnotations;

namespace UserApi.Model.Domain
{
    public class UserDetails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long Phone { get; set; }
        public string Bio { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [EmailAddress]
        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
