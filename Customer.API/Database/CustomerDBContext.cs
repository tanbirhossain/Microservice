using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Customer.API.Database
{
    public partial class CustomerDBContext : DbContext
    {
        public CustomerDBContext()
        {
        }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.250,52149;Database=CustomerDB;user id=sa;password=123456789;");
            }
          
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<tblDepartment>(entity =>
            {
                entity.ToTable("tblDepartment");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.DepartmentHead).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<tblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.tblEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__tblEmploy__Depar__4BAC3F29");
            });

            modelBuilder.Entity<tbl_Customer>(entity =>
            {
                entity.ToTable("tbl_Customer");

                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
