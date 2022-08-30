using EmployeesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesWeb.Models 
{
    public partial class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {

        }

        public DbSet<Employee>? Employees { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}