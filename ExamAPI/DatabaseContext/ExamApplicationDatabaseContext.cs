using ExamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.DatabaseContext;

public class ExamApplicationDatabaseContext : DbContext
{
    public ExamApplicationDatabaseContext(DbContextOptions op) : base(op) { }

    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Quastion> Quastions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Subject>()
            .HasMany(c => c.Quastions)
            .WithOne(c => c.Subject)
            .HasForeignKey(c => c.SubjectId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        modelBuilder.Entity<Quastion>()
            .HasMany(c => c.Answers)
            .WithOne(c => c.Quastion)
            .HasForeignKey(c => c.QuastionId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
