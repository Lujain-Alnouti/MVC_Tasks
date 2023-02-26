using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cccccccccccccc011.Models;

public partial class Core2Context : DbContext
{
    public Core2Context()
    {
    }

    public Core2Context(DbContextOptions<Core2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Doctors2> Doctors2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Core2;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.Property(e => e.ClinicImage).IsUnicode(false);
            entity.Property(e => e.ClinicName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doctors2>(entity =>
        {
            entity.ToTable("Doctors2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctors2s)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_Doctors2_Clinics");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
