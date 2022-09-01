using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Contexts;

public class KodlamaIoDevsDbContext : DbContext
{
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    
    public KodlamaIoDevsDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(pl =>
        {
            pl.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            pl.Property(p => p.Id).HasColumnName("Id");
            pl.Property(p => p.Name).HasColumnName("Name");

            pl.HasData( 
                new (){Id = 1,Name = "C#"},
                new (){Id=2,Name="Java"}
            );

        });
    }
}