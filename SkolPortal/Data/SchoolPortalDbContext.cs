using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkolPortal.Entities;

#nullable disable

namespace SkolPortal.Data
{
    public partial class SchoolPortalDbContext : DbContext
    {
        public SchoolPortalDbContext()
        {
        }

        public SchoolPortalDbContext(DbContextOptions<SchoolPortalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SchoolClass> SchoolClasses { get; set; }
        public virtual DbSet<SchoolClassStudent> SchoolClassStudents { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SchoolClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<SchoolClassStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__SchoolCl__32C52B99EB43754B");

                entity.ToTable("SchoolClassStudent");

                entity.Property(e => e.Created).HasColumnType("date");

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolClassStudents)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
