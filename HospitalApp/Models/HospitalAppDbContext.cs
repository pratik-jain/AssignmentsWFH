using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospitalApp.Models
{
    public partial class HospitalAppDbContext : DbContext
    {
        public HospitalAppDbContext()
        {
        }

        public HospitalAppDbContext(DbContextOptions<HospitalAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Assistants> Assistants { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Drugs> Drugs { get; set; }
        public virtual DbSet<PatientDrugs> PatientDrugs { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Treatements> Treatements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PRATIKPC\\SQLEXPRESS;Database=HospitalAppDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointments_Doctors");
            });

            modelBuilder.Entity<Assistants>(entity =>
            {
                entity.HasKey(e => e.AssistantId);

                entity.Property(e => e.AssistantName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assistants)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assistants_Departments");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorSpectiality)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctors_Departments");
            });

            modelBuilder.Entity<Drugs>(entity =>
            {
                entity.HasKey(e => e.DrugId);

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientDrugs>(entity =>
            {
                entity.HasKey(e => e.PatientDrugId);

                entity.Property(e => e.PatientDrugId).ValueGeneratedNever();

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.PatientDrugs)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientDrugs_Drugs");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientDrugs)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientDrugs_Patients");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Disease)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .IsRequired()
                    .HasColumnName("DOB")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patients_Appointments");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patients_Departments");
            });

            modelBuilder.Entity<Treatements>(entity =>
            {
                entity.HasKey(e => e.TreatementId);

                entity.Property(e => e.TreatementId).HasColumnName("TreatementID");

                entity.HasOne(d => d.Assistant)
                    .WithMany(p => p.Treatements)
                    .HasForeignKey(d => d.AssistantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treatements_Assistants");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Treatements)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treatements_Patients");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Treatements)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treatements_Treatements");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
