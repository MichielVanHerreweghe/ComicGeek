using ComicGeek.Domain.Comics;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComicGeek.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<ComicSeries> ComicSeries => Set<ComicSeries>();
    public DbSet<Comic> Comics => Set<Comic>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 2);

        configurationBuilder.Properties<string>()
            .HaveMaxLength(4_000);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
