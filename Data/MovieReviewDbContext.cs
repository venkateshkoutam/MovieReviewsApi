using Microsoft.EntityFrameworkCore;
using MovieReview.Models;

namespace MovieReview.Data
{
    public class MovieReviewDbContext : DbContext
    {

        public MovieReviewDbContext(DbContextOptions<MovieReviewDbContext> options) : base(options)
        {
        }

        public DbSet<MoviewReviews> MovieReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviewReviews>()
                .ToTable("MoviewReviews");

            base.OnModelCreating(modelBuilder);
        }
    }
}

