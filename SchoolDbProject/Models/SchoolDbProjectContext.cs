using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class SchoolDbProjectContext : DbContext
    {
        public SchoolDbProjectContext()
        {
        }

        public SchoolDbProjectContext(DbContextOptions<SchoolDbProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseGrade> CourseGrade { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SchoolClass> SchoolClass { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7C3L3U47; Initial Catalog = SchoolDbProject; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FteacherId).HasColumnName("FTeacherId");

                entity.HasOne(d => d.Fteacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.FteacherId)
                    .HasConstraintName("FK__tblCourse__FTeac__300424B4");
            });

            modelBuilder.Entity<CourseGrade>(entity =>
            {
                entity.Property(e => e.FcourseId).HasColumnName("FCourseId");

                entity.Property(e => e.FgradeId).HasColumnName("FGradeId");

                entity.Property(e => e.FstudentId).HasColumnName("FStudentId");

                entity.Property(e => e.FteacherId).HasColumnName("FTeacherId");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.HasOne(d => d.Fcourse)
                    .WithMany(p => p.CourseGrade)
                    .HasForeignKey(d => d.FcourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCourse__FCour__30F848ED");

                entity.HasOne(d => d.Fgrade)
                    .WithMany(p => p.CourseGrade)
                    .HasForeignKey(d => d.FgradeId)
                    .HasConstraintName("FK__tblCourse__FGrad__31EC6D26");

                entity.HasOne(d => d.Fstudent)
                    .WithMany(p => p.CourseGrade)
                    .HasForeignKey(d => d.FstudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCourse__FStud__33D4B598");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__tblEmplo__AF2DBB995B156AB4");

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasColumnName("EmpFName")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasColumnName("EmpLName")
                    .HasMaxLength(50);

                entity.Property(e => e.FroleId).HasColumnName("FRoleId");

                entity.Property(e => e.HiringDate).HasColumnType("date");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Frole)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.FroleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblEmploy__FRole__33D4B598");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.EmpRole)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SchoolClass>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__tblClass__CB1927C0713A82D6");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FclassId).HasColumnName("FClassId");

                entity.Property(e => e.StudentFname)
                    .IsRequired()
                    .HasColumnName("StudentFName")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentLname)
                    .IsRequired()
                    .HasColumnName("StudentLName")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentSocSecNum)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Fclass)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.FclassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblStuden__FClas__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
