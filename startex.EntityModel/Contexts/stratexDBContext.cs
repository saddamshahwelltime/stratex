using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using startex.EntityModel.Models;

#nullable disable

namespace startex.EntityModel.Contexts
{
    public partial class stratexDBContext : DbContext
    {
        public stratexDBContext()
        {
        }

        public stratexDBContext(DbContextOptions<stratexDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Leaf> Leaves { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=UAT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Break>(entity =>
            {
                entity.ToTable("Breaks", "schedule");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ActivityId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ActivityID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Breaks)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Breaks_Activities");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Breaks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Breaks_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Leaf>(entity =>
            {
                entity.ToTable("Leaves", "schedule");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ActivityId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ActivityID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leaves_Activities");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leaves_Employees");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shifts", "schedule");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ActivityId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ActivityID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shifts_Activities");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shifts_Employees");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
