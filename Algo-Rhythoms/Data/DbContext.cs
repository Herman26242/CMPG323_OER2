using Algo_Rhythoms.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<UserCredential> UserCredentials { get; set; }
    public DbSet<FAQ> FAQ { get; set; }
    public DbSet<SDL> SDL { get; set; }
    public DbSet<OERWebsite> OERWebsites { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User configuration
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserID);

        modelBuilder.Entity<User>()
            .Property(u => u.UserID)
            .ValueGeneratedOnAdd();

        // UserCredential configuration
        modelBuilder.Entity<UserCredential>()
            .HasKey(uc => uc.CredentialID); // Set the primary key

        modelBuilder.Entity<UserCredential>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCredentials)
            .HasForeignKey(uc => uc.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FAQ>()
            .Property(f => f.Answer)
            .IsRequired()
            .HasMaxLength(1000); // Set answer to be required with a max length

        modelBuilder.Entity<FAQ>()
            .HasOne<User>() // Configure CreatedBy relationship
            .WithMany() // Assuming a User can create many FAQs
            .HasForeignKey(f => f.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for created user

        modelBuilder.Entity<FAQ>()
            .HasOne<User>() // Configure UpdatedBy relationship
            .WithMany() // Assuming a User can update many FAQs
            .HasForeignKey(f => f.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for updated user

        // Configure the primary key for SelfDirectedLearningResource
        modelBuilder.Entity<SDL>()
            .HasKey(r => r.ID);

        // Configure the primary key for OERWebsite
        modelBuilder.Entity<OERWebsite>()
            .HasKey(o => o.ID);

    }
}
