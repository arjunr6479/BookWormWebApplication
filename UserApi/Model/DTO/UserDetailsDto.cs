using System.ComponentModel.DataAnnotations;
using UserApi.Model.Domain;

namespace UserApi.Model.Dto
{
    public class UserDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Phone { get; set; }
        public string Bio { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
