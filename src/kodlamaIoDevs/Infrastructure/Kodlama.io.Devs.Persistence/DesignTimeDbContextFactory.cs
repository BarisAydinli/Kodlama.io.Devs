using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kodlama.io.Devs.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KodlamaIoDevsDbContext>
{
    public KodlamaIoDevsDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<KodlamaIoDevsDbContext> optionsBuilder = new();

        optionsBuilder.UseSqlServer("Server=HomeComputer;Database=KodlamaIoDevsDb;Trusted_Connection=true");

        return new KodlamaIoDevsDbContext(optionsBuilder.Options);
    }
}