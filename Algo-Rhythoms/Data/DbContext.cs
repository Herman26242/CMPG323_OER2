using Microsoft.EntityFrameworkCore;
using Algo_Rhythoms.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define the primary key for User
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserID); // Primary key

        // Ensure UserID is an identity column in the database schema
        modelBuilder.Entity<User>()
            .Property(u => u.UserID)
            .ValueGeneratedOnAdd(); // Indicates that UserID is auto-incremented

        //  modelBuilder.Entity<User>()
        //      .HasMany(u => u.UploadedFiles)
        //      .WithOne(f => f.User)
        //      .HasForeignKey(f => f.UserID);

        //  modelBuilder.Entity<User>()
        //      .HasMany(u => u.FileModerations)
        //      .WithOne(fm => fm.Moderator)
        //      .HasForeignKey(fm => fm.ModeratorID);

        //  modelBuilder.Entity<User>()
        //    .HasMany(u => u.Ratings)
        //    .WithOne(r => r.User)
        //    .HasForeignKey(r => r.UserID);

           }
}
