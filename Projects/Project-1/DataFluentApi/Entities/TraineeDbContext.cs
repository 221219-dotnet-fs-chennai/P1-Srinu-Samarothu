using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataFluentApi.Entities;

public partial class TraineeDbContext : DbContext
{
    //private string connectionString = File.ReadAllText(@"C:\Revature\P1-Srinu-Samarothu\Projects\Project-1\UI-Console\ConnectionString.txt");
    public TraineeDbContext()
    {
    }

    public TraineeDbContext(DbContextOptions<TraineeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TraineeContactDetail> TraineeContactDetails { get; set; }

    public virtual DbSet<TraineeLogin> TraineeLogins { get; set; }

    public virtual DbSet<TraineeTrainerDetail> TraineeTrainerDetails { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(connectionString);*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK_TID");

            entity.ToTable("Education", "Trainee");

            entity.Property(e => e.Tid)
                .ValueGeneratedNever()
                .HasColumnName("TID");
            entity.Property(e => e.PgCollege)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PG_college");
            entity.Property(e => e.PgPassoutYear).HasColumnName("PG_passout_year");
            entity.Property(e => e.PgPercentage).HasColumnName("PG_percentage");
            entity.Property(e => e.UgCollege)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UG_college");
            entity.Property(e => e.UgPassoutYear).HasColumnName("UG_passout_year");
            entity.Property(e => e.UgPercentage).HasColumnName("UG_percentage");

            entity.HasOne(d => d.TidNavigation).WithOne(p => p.Education)
                .HasForeignKey<Education>(d => d.Tid)
                .HasConstraintName("FK_EduTID");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.Tid }).HasName("PK_Company_TID");

            entity.ToTable("Experience", "Trainee");

            entity.Property(e => e.Company)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Tid).HasColumnName("TID");
            entity.Property(e => e.Designation)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OverallExperience).HasColumnName("Overall_Experience");

            entity.HasOne(d => d.TidNavigation).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.Tid)
                .HasConstraintName("FK_ExpTID");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => new { e.Skill1, e.Tid }).HasName("PK_Skill_TID");

            entity.ToTable("Skills", "Trainee");

            entity.Property(e => e.Skill1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Skill");
            entity.Property(e => e.Tid).HasColumnName("TID");

            entity.HasOne(d => d.TidNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Tid)
                .HasConstraintName("FK_SkillsTID");
        });

        modelBuilder.Entity<TraineeContactDetail>(entity =>
        {
            entity.HasKey(e => e.MobileNumber).HasName("PK_Mobile_number");

            entity.ToTable("Trainee.Contact_details");

            entity.HasIndex(e => e.Tid, "UQ_id").IsUnique();

            entity.Property(e => e.MobileNumber)
                .ValueGeneratedNever()
                .HasColumnName("Mobile_number");
            entity.Property(e => e.AddressLane)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("Address_lane");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Mail_id");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Tid).HasColumnName("TID");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.TidNavigation).WithOne(p => p.TraineeContactDetail)
                .HasForeignKey<TraineeContactDetail>(d => d.Tid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TID");
        });

        modelBuilder.Entity<TraineeLogin>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK_Email");

            entity.ToTable("Trainee.Login");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cdstatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CDstatus");
            entity.Property(e => e.Edstatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("EDstatus");
            entity.Property(e => e.Edustatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("EDUstatus");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sdstatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SDstatus");
            entity.Property(e => e.Tdstatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("TDstatus");
        });

        modelBuilder.Entity<TraineeTrainerDetail>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK_Trainer_Id");

            entity.ToTable("Trainee.Trainer_details");

            entity.HasIndex(e => e.Mail, "UQ_mail").IsUnique();

            entity.Property(e => e.Tid)
                .ValueGeneratedNever()
                .HasColumnName("TID");
            entity.Property(e => e.Dob)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DOB");
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

            entity.HasOne(d => d.MailNavigation).WithOne(p => p.TraineeTrainerDetail)
                .HasForeignKey<TraineeTrainerDetail>(d => d.Mail)
                .HasConstraintName("FK_mail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
