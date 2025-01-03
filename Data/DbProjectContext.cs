﻿using System;
using System.Collections.Generic;
using DbProject_School.Models;
using Microsoft.EntityFrameworkCore;

namespace DbProject_School.Data;

public partial class DbProjectContext : DbContext
{
    public DbProjectContext()
    {
    }

    public DbProjectContext(DbContextOptions<DbProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseGradeStat> CourseGradeStats { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradesMapping> GradesMappings { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGradeStat> StudentGradeStats { get; set; }

    public virtual DbSet<VwAverageWorkRoleSalaryWithTotal> VwAverageWorkRoleSalaryWithTotals { get; set; }

    public virtual DbSet<VwStudentGradeInfo> VwStudentGradeInfos { get; set; }

    public virtual DbSet<VwWorkRoleSalaryWithTotal> VwWorkRoleSalaryWithTotals { get; set; }

    public virtual DbSet<WorkRole> WorkRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-GFMLGC10\\SQLEXPRESS;Initial Catalog=Lab3_ORM;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C0B5757DE1");

            entity.Property(e => e.ClassName).HasMaxLength(15);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7C193D48D");

            entity.Property(e => e.CourseName).HasMaxLength(35);
            entity.Property(e => e.CourseSubject).HasMaxLength(30);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Courses__Teacher__59FA5E80");
        });

        modelBuilder.Entity<CourseGradeStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CourseGradeStats");

            entity.Property(e => e.CourseName).HasMaxLength(35);
            entity.Property(e => e.MaxGrade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MinGrade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11A627D9F5");

            entity.HasIndex(e => e.FkpersonId, "UQ__Employee__9D37476F2887CD7F").IsUnique();

            entity.Property(e => e.EmployeeSalary).HasColumnType("money");
            entity.Property(e => e.FkpersonId).HasColumnName("FKPersonId");
            entity.Property(e => e.FkworkRole)
                .HasMaxLength(35)
                .HasColumnName("FKWorkRole");

            entity.HasOne(d => d.Fkperson).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.FkpersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__FKPer__4F7CD00D");

            entity.HasOne(d => d.FkworkRoleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FkworkRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__FKWor__5070F446");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A5786ADF418");

            entity.HasIndex(e => new { e.FkcourseId, e.GradeDate }, "IX_Grades_CourseId_GradeDate");

            entity.HasIndex(e => e.GradeDate, "IX_Grades_GradeDate");

            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseId");
            entity.Property(e => e.FkgradeLetter)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FKGradeLetter");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentId");
            entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherId");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FKCourse__208CD6FA");

            entity.HasOne(d => d.FkgradeLetterNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkgradeLetter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FKGradeL__1F98B2C1");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkstudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FKStuden__2180FB33");

            entity.HasOne(d => d.Fkteacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkteacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FKTeache__22751F6C");
        });

        modelBuilder.Entity<GradesMapping>(entity =>
        {
            entity.HasKey(e => e.GradeLetter).HasName("PK__GradesMa__1C8CA5AE11F9EF2A");

            entity.ToTable("GradesMapping");

            entity.Property(e => e.GradeLetter)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__People__AA2FFBE50E4A0E0A");

            entity.HasIndex(e => e.SocialSecurityNumber, "UQ__People__2EFDFD39472160C0").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9944D5C491");

            entity.HasIndex(e => e.ClassId, "IX_Students_ClassId");

            entity.HasIndex(e => e.PersonId, "UQ__Students__AA2FFBE4B09F3052").IsUnique();

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__ClassI__19DFD96B");

            entity.HasOne(d => d.Person).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Person__1AD3FDA4");
        });

        modelBuilder.Entity<StudentGradeStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StudentGradeStats");

            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.MaxGrade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MinGrade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwAverageWorkRoleSalaryWithTotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AverageWorkRoleSalaryWithTotal");

            entity.Property(e => e.AverageSalary).HasColumnType("money");
            entity.Property(e => e.WorkRole).HasMaxLength(35);
        });

        modelBuilder.Entity<VwStudentGradeInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentGradeInfo");

            entity.Property(e => e.CourseName).HasMaxLength(35);
            entity.Property(e => e.CourseTeacherName).HasMaxLength(71);
            entity.Property(e => e.Grade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GradeSetterTeacherName).HasMaxLength(71);
            entity.Property(e => e.StudentFirstName).HasMaxLength(35);
            entity.Property(e => e.StudentLastName).HasMaxLength(35);
        });

        modelBuilder.Entity<VwWorkRoleSalaryWithTotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_WorkRoleSalaryWithTotal");

            entity.Property(e => e.TotalSalary).HasColumnType("money");
            entity.Property(e => e.WorkRole).HasMaxLength(35);
        });

        modelBuilder.Entity<WorkRole>(entity =>
        {
            entity.HasKey(e => e.WorkRole1).HasName("PK__WorkRole__3A252EF8B0012EDA");

            entity.Property(e => e.WorkRole1)
                .HasMaxLength(35)
                .HasColumnName("WorkRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
