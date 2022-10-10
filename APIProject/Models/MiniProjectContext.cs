using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIProject.Models
{
    public partial class MiniProjectContext : DbContext
    {
        public MiniProjectContext()
        {
        }

        public MiniProjectContext(DbContextOptions<MiniProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JobPosting> JobPostings { get; set; }
        public virtual DbSet<JobRole> JobRoles { get; set; }
        public virtual DbSet<JobSkill> JobSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SLB-23GVBK3;Database=MiniProject;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Email_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.JobSkillTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Job_skill_title");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
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
                entity.HasNoKey();

                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
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

                entity.ToTable("job_posting");

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

                entity.ToTable("job_role");

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");

                entity.Property(e => e.JobRoleSkill).HasColumnName("job_role_skill");

                entity.Property(e => e.JobRoleTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_role_title");
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("job_skills");

                entity.Property(e => e.JobSkillsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("job_skills_id");

                entity.Property(e => e.JobSkillsTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_skills_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
