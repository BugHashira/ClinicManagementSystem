using ClinicManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

    // DbSets (tables)
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientIdentity> PatientIdentities { get; set; }
    public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Facility - Clinic (1:N)
        modelBuilder.Entity<Facility>()
            .HasMany(f => f.Clinics)
            .WithOne(c => c.Facility)
            .HasForeignKey(c => c.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);

        // Patient - InsurancePolicy (1:N)
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.InsurancePolicies)
            .WithOne(i => i.Patient)
            .HasForeignKey(i => i.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Patient - Appointment (1:N)
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Clinic - Appointment (1:N)
        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.Appointments)
            .WithOne(a => a.Clinic)
            .HasForeignKey(a => a.ClinicId)
            .OnDelete(DeleteBehavior.Cascade);

        // Wallet - Patient (1:1)
        modelBuilder.Entity<Wallet>()
            .HasOne(w => w.Patient)
            .WithOne(p => p.Wallet)
            .HasForeignKey<Wallet>(w => w.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Invoice - Patient (1:N)
        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Patient)
            .WithMany(p => p.Invoices)
            .HasForeignKey(i => i.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Invoice - InvoiceItem (1:N)
        modelBuilder.Entity<Invoice>()
            .HasMany(i => i.Items)
            .WithOne(it => it.Invoice)
            .HasForeignKey(it => it.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Payment - Invoice (1:N)
        modelBuilder.Entity<Invoice>()
            .HasMany(i => i.Payments)
            .WithOne(p => p.Invoice)
            .HasForeignKey(p => p.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Audit logging
        modelBuilder.Entity<AuditLog>()
            .Property(a => a.PerformedAt);
    }
}