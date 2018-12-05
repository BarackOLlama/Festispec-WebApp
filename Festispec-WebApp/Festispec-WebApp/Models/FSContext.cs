using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Festispec_WebApp.Models
{
    public partial class FSContext : DbContext
    {
        public FSContext()
        {
        }

        public FSContext(DbContextOptions<FSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Availabilities> Availabilities { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EventDates> EventDates { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<InspectionDates> InspectionDates { get; set; }
        public virtual DbSet<InspectionInspectors> InspectionInspectors { get; set; }
        public virtual DbSet<Inspections> Inspections { get; set; }
        public virtual DbSet<Inspectors> Inspectors { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Quotations> Quotations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:berm.database.windows.net,1433;Initial Catalog=festispec;Persist Security Info=False;User ID=berm;Password=Bart_2018!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.Accounts_dbo.Roles_RoleId");
            });

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasIndex(e => e.InspectorId)
                    .HasName("IX_InspectorId");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("IX_QuestionId");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.InspectorId)
                    .HasConstraintName("FK_dbo.Answers_dbo.Inspectors_InspectorId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_dbo.Answers_dbo.Questions_QuestionId");
            });

            modelBuilder.Entity<Availabilities>(entity =>
            {
                entity.HasIndex(e => e.InspectorId)
                    .HasName("IX_InspectorId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.InspectorId)
                    .HasConstraintName("FK_dbo.Availabilities_dbo.Inspectors_InspectorId");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Customers_CustomerId");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.ChamberOfCommerceNumber).HasColumnType("decimal(8, 0)");

                entity.Property(e => e.StartingDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventDates>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.HasIndex(e => e.EventDateId)
                    .HasName("IX_EventDateId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Events_dbo.Customers_CustomerId");

                entity.HasOne(d => d.EventDate)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventDateId)
                    .HasConstraintName("FK_dbo.Events_dbo.EventDates_EventDateId");
            });

            modelBuilder.Entity<InspectionDates>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InspectionInspectors>(entity =>
            {
                entity.HasKey(e => new { e.InspectionId, e.InspectorId })
                    .HasName("PK_dbo.InspectionInspectors");

                entity.HasIndex(e => e.InspectionId)
                    .HasName("IX_Inspection_Id");

                entity.HasIndex(e => e.InspectorId)
                    .HasName("IX_Inspector_Id");

                entity.Property(e => e.InspectionId).HasColumnName("Inspection_Id");

                entity.Property(e => e.InspectorId).HasColumnName("Inspector_Id");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.InspectionInspectors)
                    .HasForeignKey(d => d.InspectionId)
                    .HasConstraintName("FK_dbo.InspectionInspectors_dbo.Inspections_Inspection_Id");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.InspectionInspectors)
                    .HasForeignKey(d => d.InspectorId)
                    .HasConstraintName("FK_dbo.InspectionInspectors_dbo.Inspectors_Inspector_Id");
            });

            modelBuilder.Entity<Inspections>(entity =>
            {
                entity.HasIndex(e => e.EventId)
                    .HasName("IX_EventId");

                entity.HasIndex(e => e.InspectionDateId)
                    .HasName("IX_InspectionDateId");

                entity.HasIndex(e => e.StatusId)
                    .HasName("IX_StatusId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_dbo.Inspections_dbo.Events_EventId");

                entity.HasOne(d => d.InspectionDate)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.InspectionDateId)
                    .HasConstraintName("FK_dbo.Inspections_dbo.InspectionDates_InspectionDateId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_dbo.Inspections_dbo.Status_StatusId");
            });

            modelBuilder.Entity<Inspectors>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("IX_AccountId");

                entity.Property(e => e.CertificationDate).HasColumnType("datetime");

                entity.Property(e => e.InvalidDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Inspectors)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_dbo.Inspectors_dbo.Accounts_AccountId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Questionnaires>(entity =>
            {
                entity.HasIndex(e => e.InspectionId)
                    .HasName("IX_InspectionId");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.InspectionId)
                    .HasConstraintName("FK_dbo.Questionnaires_dbo.Inspections_InspectionId");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasIndex(e => e.QuestionTypeId)
                    .HasName("IX_QuestionTypeId");

                entity.HasIndex(e => e.QuestionnaireId)
                    .HasName("IX_QuestionnaireId");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_dbo.Questions_dbo.QuestionTypes_QuestionTypeId");

                entity.HasOne(d => d.Questionnaire)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionnaireId)
                    .HasConstraintName("FK_dbo.Questions_dbo.Questionnaires_QuestionnaireId");
            });

            modelBuilder.Entity<Quotations>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.HasIndex(e => e.InspectionId)
                    .HasName("IX_InspectionId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Quotations_dbo.Customers_CustomerId");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.InspectionId)
                    .HasConstraintName("FK_dbo.Quotations_dbo.Inspections_InspectionId");
            });
        }
    }
}
