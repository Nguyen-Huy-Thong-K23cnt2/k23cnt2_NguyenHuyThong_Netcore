using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nht_lesson10.Models;

public partial class NhtK23cnt2lesson10Context : DbContext
{
    public NhtK23cnt2lesson10Context()
    {
    }

    public NhtK23cnt2lesson10Context(DbContextOptions<NhtK23cnt2lesson10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-PJ0J5DU8\\SQLEXPRESS;Database=NhtK23CNT2Lesson10;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("Category");

            entity.Property(e => e.CateId).HasColumnName("CateID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
