using Microsoft.EntityFrameworkCore;
using Prescriptions.Models;

namespace Prescriptions.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected DatabaseContext(){}
    
    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        
        modelBuilder.Entity<Prescription>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(p => p.IdPatient);
            
        modelBuilder.Entity<Prescription>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(p => p.IdDoctor);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Medicament>()
            .WithMany()
            .HasForeignKey(pm => pm.IdMedicament);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Prescription>()
            .WithMany()
            .HasForeignKey(pm => pm.IdPrescription);
    }
}