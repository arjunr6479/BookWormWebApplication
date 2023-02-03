using BookWormWebAPP.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookWormWebApp.Data
{
    public class BookDetailsDbContext : DbContext
    {
        public BookDetailsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }
        public DbSet<CategoryDetails> CategoryDetails { get; set; }

    }
}
