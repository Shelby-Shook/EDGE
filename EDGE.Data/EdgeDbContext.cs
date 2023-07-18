using Microsoft.EntityFrameworkCore;

namespace EDGE.Data;

public class EdgeDbContext : DbContext
{
    public EdgeDbContext(DbContextOptions<EdgeDbContext> options) 
        : base(options) { }

    public DbSet<Users> Users { get; set; } 
    public DbSet<WorkoutLog> WorkoutLogs { get; set; }

    public DbSet<PR> PersonalRecords { get; set; }
}