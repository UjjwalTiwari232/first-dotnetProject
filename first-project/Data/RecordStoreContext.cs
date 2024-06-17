using first_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace first_project.Data;

public class RecordStoreContext(DbContextOptions<RecordStoreContext> options):DbContext(options)
{
    public DbSet<Record> Records => Set<Record>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {Id = 1, Name = "Fighting"},
            new {Id = 2, Name = "Sports"},
            new {Id = 3, Name = "Racing"},
            new {Id = 4, Name = "Open World"},
            new {Id = 5, Name = "RPG"},
            new {Id = 6, Name = "FPP"}
        );
    }
}
