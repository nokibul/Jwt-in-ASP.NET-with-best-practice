using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Agency.Models.Entities.Agency;
using Agency.Models.Entities.Member;
using Agency.Models.Entities.MemberRole;
using Agency.Models.Entities.Role;
using Agency.Models.Entities.RolePermission;
using Agency.Models.Entities.Permission;

namespace Agency.Models.MyContext;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
    : base(options)
    { }
    public DbSet<AgencyEntity> Agencies { get; set; }
    public DbSet<MemberEntity> Members { get; set; }
    public DbSet<MemberRoleEntity> MemberRoles { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        ConfigureMemberEntity(modelBuilder);
        ConfigureMemberRoleEntity(modelBuilder);
        ConfigureRolePermissionEntity(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public void ConfigureMemberEntity(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<MemberEntity>()
        //         .HasOne(a => a.Agency)
        //         .WithMany(b => b.Members)
        //         .HasForeignKey(c => c.AgencyId);

    }
    public void ConfigureMemberRoleEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemberRoleEntity>()
        .HasKey(mr => new { mr.MemberId, mr.RoleId });

        modelBuilder.Entity<MemberRoleEntity>()
            .HasOne(mr => mr.Member)
            .WithMany(m => m.MemberRoles)
            .HasForeignKey(mr => mr.MemberId);

        modelBuilder.Entity<MemberRoleEntity>()
            .HasOne(mr => mr.Role)
            .WithMany(r => r.RoleMembers)
            .HasForeignKey(mr => mr.RoleId);

    }

    public void ConfigureRolePermissionEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RolePermissionEntity>()
        .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermissionEntity>()
            .HasOne(r => r.Role)
            .WithMany(rp => rp.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermissionEntity>()
        .HasOne(r => r.Permission)
        .WithMany(rp => rp.PermissionRoles)
        .HasForeignKey(rp => rp.PermissionId);

    }

}