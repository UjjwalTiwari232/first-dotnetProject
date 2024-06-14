using first_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace first_project.Data;

public class RecordStoreContext(DbContextOptions<RecordStoreContext> options):DbContext(options)
{
    public DbSet<Record> Records => Set<Record>();

    public DbSet<Genre> Genres => Set<Genre>();
}
