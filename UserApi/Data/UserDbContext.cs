using Microsoft.EntityFrameworkCore;
using UserApi.Model.Domain;

namespace UserApi.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
