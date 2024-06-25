using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamProvider.core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiService> ApiServices { get; set; } = null!;
        public virtual DbSet<CompanyInfo> CompanyInfos { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; } = null!;
        public virtual DbSet<UserExam> UserExams { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=C##SYS_EXAMPROVIDER;PASSWORD=0000;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##SYS_EXAMPROVIDER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ApiService>(entity =>
            {
                entity.HasKey(e => e.ApiId)
                    .HasName("SYS_C008689");

                entity.ToTable("API_SERVICE");

                entity.Property(e => e.ApiId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("API_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_NAME");

                entity.Property(e => e.UniqueKey)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UNIQUE_KEY");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("SYS_C008693");

                entity.ToTable("COMPANY_INFO");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.CommercialrecordImg)
                    .HasColumnType("CLOB")
                    .HasColumnName("COMMERCIALRECORD_IMG");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Description)
                    .HasColumnType("CLOB")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LogoImg)
                    .HasColumnType("CLOB")
                    .HasColumnName("LOGO_IMG");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION_NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("EXAM");

                entity.Property(e => e.ExamId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAM_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ExamDescription)
                    .HasColumnType("CLOB")
                    .HasColumnName("EXAM_DESCRIPTION");

                entity.Property(e => e.ExamDuration)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXAM_DURATION");

                entity.Property(e => e.ExamName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXAM_NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("QUESTION");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUESTION_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ExamId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXAM_ID");

                entity.Property(e => e.QuestionDatecreation)
                    .HasColumnType("CLOB")
                    .HasColumnName("QUESTION_DATECREATION");

                entity.Property(e => e.QuestionLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QUESTION_LEVEL");

                entity.Property(e => e.QuestionType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QUESTION_TYPE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EXAMID");
            });

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("SYS_C008703");

                entity.ToTable("QUESTION_OPTION");

                entity.Property(e => e.OptionId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OPTION_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.IsCorrect)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IS_CORRECT");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUESTION_ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionOptions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_QUEID");
            });

            modelBuilder.Entity<UserExam>(entity =>
            {
                entity.ToTable("USER_EXAM");

                entity.Property(e => e.UserExamId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_EXAM_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ExamId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXAM_ID");

                entity.Property(e => e.ScorEmark)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SCOR_EMARK");

                entity.Property(e => e.ScoreRate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SCORE_RATE");

                entity.Property(e => e.UniqueId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("UNIQUE_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.UserExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EXAMINFOID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExams)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERINFOID");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SYS_C008695");

                entity.ToTable("USER_INFO");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Datecreation)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DATECREATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLEID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C008691");

                entity.ToTable("USER_ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_AT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
