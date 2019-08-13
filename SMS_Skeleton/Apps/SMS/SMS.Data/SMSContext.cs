namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Models;

    // ReSharper disable once InconsistentNaming
    public class SMSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=TONI\SQLEXPRESS;Database=SMSDb;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(x => x.Cart)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cart>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Cart)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}