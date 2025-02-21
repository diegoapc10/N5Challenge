using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public partial class N5challengeContext : DbContext
{
    public N5challengeContext()
    {
    }

    public N5challengeContext(DbContextOptions<N5challengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost; database=N5Challenge; user id=sa; password=123; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07C242B0C7");

            entity.Property(e => e.EmployeeForname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeSurname)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PermissionTypeNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.PermissionType)
                .HasConstraintName("FK__Permissio__Permi__398D8EEE");
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07ECC4A7A1");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
