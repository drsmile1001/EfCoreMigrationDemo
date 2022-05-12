using Microsoft.EntityFrameworkCore;

namespace EfCoreMigrationDemo.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; } = null!;

    public virtual DbSet<Group> Groups { get; set; } = null!;

    public virtual DbSet<Claim> Claims { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("ID");

            entity.Property(e => e.NickName)
                .HasComment("暱稱");

            entity.Property(e => e.Email)
                .HasComment("信箱");

            entity.HasMany(e => e.Groups)
                .WithMany(e => e.People)
                .UsingEntity<PersonGroup>(c =>
                {
                    c.Property(c => c.PersonId)
                        .HasComment("人員ID");

                    c.Property(c => c.GroupId)
                        .HasComment("群組ID");

                    c.HasOne(e => e.Person)
                        .WithMany()
                        .HasForeignKey(e => e.PersonId)
                        .OnDelete(DeleteBehavior.Cascade);

                    c.HasOne(e => e.Group)
                        .WithMany()
                        .HasForeignKey(e => e.GroupId)
                        .OnDelete(DeleteBehavior.Cascade);
                });
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("ID");

            entity.Property(e => e.Name)
                .HasComment("名稱");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("ID");

            entity.Property(e => e.Type)
                .HasComment("類型");

            entity.Property(e => e.Value)
                .HasComment("值");

            entity.HasOne(e => e.Person)
                .WithMany(e => e.Claims)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}