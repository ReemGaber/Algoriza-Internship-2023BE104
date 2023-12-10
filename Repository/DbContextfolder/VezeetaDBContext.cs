using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DomainModels;
using Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static Azure.Core.HttpHeader;

namespace Repository.DbContextfolder
{
    public class VezeetaDBContext : DbContext
    {
        public VezeetaDBContext(DbContextOptions<VezeetaDBContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointement> Appointments { get; set; }
        public DbSet<Discount> DiscountCodes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Specializations> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    AdminName="Ali",
                    AdminPassword="hgh154",
                    AdminEmail="Ali111@gmail.com",
                    Phone="1257963255",
                    DateOfBirth=new DateTime(2000,5,6),


                });
        //one to many admin&doctor relationship
        modelBuilder.Entity<Doctor>()
           .HasOne(d => d.Admin)
           .WithMany(a => a.Doctors)
           .HasForeignKey(d => d.AdminId);

            //one to many admin&patient relationship
            modelBuilder.Entity<Admin>()
               .HasMany(a => a.Patients)
               .WithOne(p => p.Admin)
               .HasForeignKey(p => p.AdminId);

            //Admin&discount code 
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Discountcodes)
                .WithOne(d => d.Admin)
                .HasForeignKey(d => d.AdminId);

            //  Doctor-Patient relationship (many-to-many)
            modelBuilder.Entity<DoctorPatient>()
            .HasKey(dp => new { dp.DoctorId, dp.PatientId });

            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId);

            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId);

            // Configure Doctor-Appointment relationship (one-to-many)
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointements)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Patient-Appointment relationship (one-to-many)
            modelBuilder.Entity<Appointement>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);


            //Doctor&feedback
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Feedbacks)
                .WithOne(f => f.Doctor)
                .HasForeignKey(f => f.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);


            // Configure Patient-Feedback relationship (one-to-many)
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Patient)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.PatientId);

            modelBuilder.Entity<Specializations>().HasData
                (
                     new Specializations { Id = 1, Name = "Cardiology" },
                     new Specializations { Id = 2, Name = "Dermatology" },
                     new Specializations { Id = 3, Name = "Gastroenterology" }
                );

            // Configure Doctor-Specialization relationship (many-to-many)
            modelBuilder.Entity<DoctorSpecialization>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecializationId });

            modelBuilder.Entity<DoctorSpecialization>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecializations)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpecialization>()
                .HasOne(ds => ds.Specialization)
                .WithMany(s => s.DoctorSpecializations)
                .HasForeignKey(ds => ds.SpecializationId);

            // Configure Patient-DiscountCode relationship
            modelBuilder.Entity<Discount>()
                 .HasOne(c => c.Patient)
                 .WithMany(p => p.DiscountCodes)
                 .HasForeignKey(c => c.PatientId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Cascade);

            //doctor &appointement
            modelBuilder.Entity<Appointement>()
           .HasOne(a => a.Doctor)
           .WithMany(d => d.Appointements)
           .HasForeignKey(a => a.DoctorId)
           .OnDelete(DeleteBehavior.Restrict);



            // DiscountCode - Appointment
            modelBuilder.Entity<Discount>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Discount)
                .HasForeignKey(a => a.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);

            




            base.OnModelCreating(modelBuilder);
        }

    }
}
