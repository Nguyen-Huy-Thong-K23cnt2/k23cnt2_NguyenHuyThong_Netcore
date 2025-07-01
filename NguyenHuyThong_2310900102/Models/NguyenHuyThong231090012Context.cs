using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenHuyThong_2310900102.Models;

public partial class NguyenHuyThong231090012Context : DbContext
{
    public NguyenHuyThong231090012Context()
    {
    }

    public NguyenHuyThong231090012Context(DbContextOptions<NguyenHuyThong231090012Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NhtEmployee> NhtEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-PJ0J5DU8\\SQLEXPRESS;Database=NguyenHuyThong_231090012;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhtEmployee>(entity =>
        {
            entity.HasKey(e => e.NhtEmpId).HasName("PK__NhtEmplo__CA96F07C55A607F5");

            entity.ToTable("NhtEmployee");

            entity.Property(e => e.NhtEmpId)
                .HasMaxLength(20)
                .HasColumnName("nhtEmpID");
            entity.Property(e => e.NhtEmpLevel)
                .HasMaxLength(20)
                .HasColumnName("nhtEmpLevel");
            entity.Property(e => e.NhtEmpName)
                .HasMaxLength(100)
                .HasColumnName("nhtEmpName");
            entity.Property(e => e.NhtEmpStartDate).HasColumnName("nhtEmpStartDate");
            entity.Property(e => e.NhtEmpStatus).HasColumnName("nhtEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
