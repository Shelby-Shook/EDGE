using EDGE.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static EDGE.Data.Entities.Identity;

namespace EDGE.Data;

public class EdgeDbContext : IdentityDbContext<UserEntity, RoleEntity, int, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    public EdgeDbContext(DbContextOptions<EdgeDbContext> options) 
        : base(options) { }

    public override DbSet<UserEntity> Users { get; set; } 
    public DbSet<WorkoutLog> WorkoutLog { get; set; }

    public DbSet<PR> PersonalRecords { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().ToTable("Users") .Ignore(u => u.UserName); // Ignore duplicate column
            modelBuilder.Entity<RoleEntity>().ToTable("Roles");
            modelBuilder.Entity<UserRoleEntity>().ToTable("UserRoles");
            modelBuilder.Entity<UserClaimEntity>().ToTable("UserClaims");
            modelBuilder.Entity<UserLoginEntity>().ToTable("UserLogins");
            modelBuilder.Entity<UserTokenEntity>().ToTable("UserTokens");
            modelBuilder.Entity<RoleClaimEntity>().ToTable("RoleClaims");
        modelBuilder.HasDefaultSchema("EDGESchema");
    }
}