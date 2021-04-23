using AhamHr.Data.Entities.Models;
using AhamHr.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities
{
    public class AhamHrContext : DbContext
    {
        public AhamHrContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AvailableTermin> AvailableTermins { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAppointment> StudentAppointments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.UserRole)
                .HasValue<Student>(UserRole.Student)
                .HasValue<Professor>(UserRole.Professor)
                .HasValue<Admin>(UserRole.Admin);

            modelBuilder.Entity<ProfessorSubject>()
                .HasKey(ps => new { ps.ProfessorId, ps.SubjectId });
            modelBuilder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.Professor)
                .WithMany(p => p.ProfessorSubjects)
                .HasForeignKey(ps => ps.ProfessorId);
            modelBuilder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.Subject)
                .WithMany(s => s.ProfessorSubjects)
                .HasForeignKey(ps => ps.SubjectId);

            modelBuilder.Entity<StudentAppointment>()
                .HasKey(sa => new { sa.StudentId, sa.AppointmentId });
            modelBuilder.Entity<StudentAppointment>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAppointments)
                .HasForeignKey(sa => sa.StudentId);
            modelBuilder.Entity<StudentAppointment>()
                .HasOne(sa => sa.Student)
                .WithMany(a => a.StudentAppointments)
                .HasForeignKey(sa => sa.AppointmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
