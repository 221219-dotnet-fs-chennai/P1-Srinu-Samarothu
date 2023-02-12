using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataFluentApi.Views;

public partial class TraineeDbContext : DbContext
{
    public TraineeDbContext()
    {
    }

    public TraineeDbContext(DbContextOptions<TraineeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VirtualTable> VirtualTables { get; set; }

/*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VirtualTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VirtualTable");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PgCollege)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PG_college");
            entity.Property(e => e.PgPassoutYear).HasColumnName("PG_passout_year");
            entity.Property(e => e.PgPercentage).HasColumnName("PG_percentage");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Tid).HasColumnName("TID");
            entity.Property(e => e.UgCollege)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UG_college");
            entity.Property(e => e.UgPassoutYear).HasColumnName("UG_passout_year");
            entity.Property(e => e.UgPercentage).HasColumnName("UG_percentage");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
