using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SRecruitAPI.Models
{
    public partial class SRecruitDBContext : DbContext
    {
        public SRecruitDBContext()
        {
        }

        public SRecruitDBContext(DbContextOptions<SRecruitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<JobPosting> JobPostings { get; set; } = null!;
        public virtual DbSet<JobRole> JobRoles { get; set; } = null!;
        public virtual DbSet<JobSkill> JobSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SLB-23GVBK3; Database=SRecruitDB; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Email_id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.JobSkillTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Job_skill_title");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.PreferredLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Preferred_location");

                entity.Property(e => e.YearOfExperience).HasColumnName("Year_of_experience");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Company_name");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JobPosting");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.JobPostingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("job_posting_id");

                entity.Property(e => e.JobPostingYoe).HasColumnName("job_posting_yoe");

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");
            });

            modelBuilder.Entity<JobRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JobRole");

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");

                entity.Property(e => e.JobRoleSkill).HasColumnName("job_role_skill");

                entity.Property(e => e.JobRoleTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_role_title");
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.JobSkillsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("job_skills_id");

                entity.Property(e => e.JobSkillsTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_skills_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
