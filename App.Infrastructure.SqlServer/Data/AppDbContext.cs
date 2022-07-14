using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Expert.Entities;
using App.Domain.Core.Operator.Entities;
using App.Domain.Core.Service.Entities;
using App.Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.SqlServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Expert> Experts { get; set; }
        public DbSet<ExpertService> ExpertServices { get; set; }
        public DbSet<ExpertServiceFile> ExpertServiceFiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationTitle> EvaluationTitles { get; set; }
        public DbSet<PastWork> PastWorks { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceFile> ServiceFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.HasMany(p => p.Tenders).WithOne(d => d.Expert).HasForeignKey(d => d.ExpertId);
                entity.HasMany(p => p.ExpertServices).WithOne(d => d.Expert).HasForeignKey(d => d.ExpertId);
            });
            modelBuilder.Entity<ExpertService>(entity =>
            {
                entity.HasIndex(e => e.ExpertId);
                entity.HasIndex(e => e.ServiceId);
                entity.HasMany(p => p.Comments).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
                entity.HasMany(p => p.expertServiceFiles).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
                entity.HasMany(p => p.PastWorks).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
                entity.HasMany(p => p.Evaluations).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
            });
            modelBuilder.Entity<ExpertServiceFile>(entity =>
            {
                entity.HasIndex(e => e.FileTypeId);
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasOne(p => p.FileType).WithMany(d => d.ExpertServiceFiles).HasForeignKey(d => d.FileTypeId);
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasIndex(e => e.UserId);
            });
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasIndex(e => e.EvaluationTitleId);
                entity.HasIndex(e => e.PastWorkId);
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasOne(p => p.EvaluationTitle).WithMany(d => d.Evaluations).HasForeignKey(d => d.EvaluationTitleId);
            });
            modelBuilder.Entity<PastWork>(entity =>
            {
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasIndex(e => e.UserId);
                entity.HasMany(p => p.Evaluations).WithOne(d => d.PastWork).HasForeignKey(d => d.PastWorkId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Tender>(entity =>
            {
                entity.HasIndex(e => e.ExpertId);
                entity.HasIndex(e => e.OrderId);
                entity.HasOne(p => p.Order).WithMany(d => d.Tenders).HasForeignKey(d => d.OrderId);
            });
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasMany(p => p.ExpertServices).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);
                entity.HasMany(p => p.ServiceFiles).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);
            });
            modelBuilder.Entity<ServiceFile>(entity =>
            {
                entity.HasIndex(e => e.ServiceId);
                entity.HasIndex(e => e.FileTypeId);
                entity.HasOne(p => p.FileType).WithMany(d => d.ServiceFiles).HasForeignKey(d => d.FileTypeId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(p => p.Comments).WithOne(d => d.User).HasForeignKey(d => d.UserId);
                entity.HasMany(p => p.Orders).WithOne(d => d.User).HasForeignKey(d => d.UserId);
                entity.HasMany(p => p.PastWorks).WithOne(d => d.User).HasForeignKey(d => d.UserId);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.OrderStateId);
                entity.HasOne(p => p.OrderState).WithMany(d => d.Orders).HasForeignKey(d => d.OrderStateId);
            });
        }
    }
}
