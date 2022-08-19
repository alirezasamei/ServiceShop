using BaseDataEntities = App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Expert.Entities;
using App.Domain.Core.Service.Entities;
using App.Domain.Core.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.BaseData.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.SqlServer.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Expert> Experts { get; set; }
        public DbSet<ExpertService> ExpertServices { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationTitle> EvaluationTitles { get; set; }
        public DbSet<PastWork> PastWorks { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<BaseDataEntities.File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var guid = new List<Guid>();
            for (int i = 0; i < 28; i++)
                guid.Add(Guid.NewGuid());

            modelBuilder.Entity<AppUser>(entity => entity.HasData(
                new AppUser { Id = 1, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser1@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser1 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 2, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser2@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser2 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser2username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 3, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser3@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser3 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser3username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 4, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser4@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser4 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser4username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 5, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser5@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser5 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser5username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 6, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser6@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser6 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser6username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 7, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser7@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser7 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser7username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 8, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser8@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser8 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser8username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 9, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser9@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser9 ", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser9username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 10, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser10@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser10", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser10username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 11, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser11@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser11", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser11username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 12, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser12@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser12", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser12username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 13, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser13@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser13", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser13username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 14, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser14@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser14", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser14username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 15, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser15@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser15", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser15username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 16, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser16@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser16", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser16username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 17, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser17@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser17", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser17username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 18, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser18@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser18", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser18username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 19, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser19@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser19", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser19username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 20, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser20@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser20", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser20username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 21, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser21@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser21", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser21username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 22, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser22@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser22", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser22username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 23, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser23@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser23", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser23username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 24, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser24@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser24", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser24username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 25, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser25@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser25", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser25username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 26, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser26@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser26", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser26username", SubmitDate = DateTime.Now, SecurityStamp = " " },
                new AppUser { Id = 27, AccessFailedCount = 0, ConcurrencyStamp = " ", Email = "AppUser27@a.com", EmailConfirmed = true, IsActive = true, IsDeleted = false, LockoutEnabled = true, Name = "AppUser27", PhoneNumber = "09123456789", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser27username", SubmitDate = DateTime.Now, SecurityStamp = " " }
                ));

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.HasOne(p => p.ImageFile).WithOne().HasForeignKey<Expert>(p => p.ImageFileId);
                entity.HasMany(p => p.Tenders).WithOne(d => d.Expert).HasForeignKey(d => d.ExpertId);
                entity.HasMany(p => p.ExpertServices).WithOne(d => d.Expert).HasForeignKey(d => d.ExpertId);
                entity.HasData(
                    new Expert { Id = 01, Address = "آدرس متخصص 1", AppUserId = 1, ImageFileId = guid[01] },
                    new Expert { Id = 02, Address = "آدرس متخصص 2", AppUserId = 2, ImageFileId = guid[02] },
                    new Expert { Id = 03, Address = "آدرس متخصص 3", AppUserId = 3, ImageFileId = guid[03] },
                    new Expert { Id = 04, Address = "آدرس متخصص 4", AppUserId = 4, ImageFileId = guid[04] },
                    new Expert { Id = 05, Address = "آدرس متخصص 5", AppUserId = 5, ImageFileId = guid[05] },
                    new Expert { Id = 06, Address = "آدرس متخصص 6", AppUserId = 6, ImageFileId = guid[06] },
                    new Expert { Id = 07, Address = "آدرس متخصص 7", AppUserId = 7, ImageFileId = guid[07] },
                    new Expert { Id = 08, Address = "آدرس متخصص 8", AppUserId = 8, ImageFileId = guid[08] },
                    new Expert { Id = 09, Address = "آدرس متخصص 9", AppUserId = 9, ImageFileId = guid[09] }
                    );
            });
            modelBuilder.Entity<ExpertService>(entity =>
            {
                entity.HasIndex(e => e.ExpertId);
                entity.HasIndex(e => e.ServiceId);
                entity.HasMany(p => p.Comments).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(p => p.expertServiceFiles).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
                entity.HasMany(p => p.PastWorks).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(p => p.Evaluations).WithOne(d => d.ExpertService).HasForeignKey(d => d.ExpertServiceId);
                entity.HasData(
                    new ExpertService { Id = 01, CreationDate = DateTime.Now, ExpertId = 1, IsActive = true, IsDeleted = false, ServiceId = 1 },
                    new ExpertService { Id = 02, CreationDate = DateTime.Now, ExpertId = 2, IsActive = true, IsDeleted = false, ServiceId = 2 },
                    new ExpertService { Id = 03, CreationDate = DateTime.Now, ExpertId = 3, IsActive = true, IsDeleted = false, ServiceId = 3 },
                    new ExpertService { Id = 04, CreationDate = DateTime.Now, ExpertId = 4, IsActive = true, IsDeleted = false, ServiceId = 4 },
                    new ExpertService { Id = 05, CreationDate = DateTime.Now, ExpertId = 5, IsActive = true, IsDeleted = false, ServiceId = 5 },
                    new ExpertService { Id = 06, CreationDate = DateTime.Now, ExpertId = 6, IsActive = true, IsDeleted = false, ServiceId = 6 },
                    new ExpertService { Id = 07, CreationDate = DateTime.Now, ExpertId = 7, IsActive = true, IsDeleted = false, ServiceId = 7 },
                    new ExpertService { Id = 08, CreationDate = DateTime.Now, ExpertId = 8, IsActive = true, IsDeleted = false, ServiceId = 8 },
                    new ExpertService { Id = 09, CreationDate = DateTime.Now, ExpertId = 9, IsActive = true, IsDeleted = false, ServiceId = 9 }
                    );
            });
            modelBuilder.Entity<BaseDataEntities.File>(entity =>
            {
                entity.HasIndex(e => e.FileTypeId);
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasIndex(e => e.ServiceId);
                entity.HasOne(p => p.FileType).WithMany().HasForeignKey(d => d.FileTypeId);
                entity.HasData(
                    new BaseDataEntities.File { Id = guid[01], CreationDate = DateTime.Now, Description = "توضیح فایل 01", Name = "File01", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[02], CreationDate = DateTime.Now, Description = "توضیح فایل 02", Name = "File02", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[03], CreationDate = DateTime.Now, Description = "توضیح فایل 03", Name = "File03", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[04], CreationDate = DateTime.Now, Description = "توضیح فایل 04", Name = "File04", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[05], CreationDate = DateTime.Now, Description = "توضیح فایل 05", Name = "File05", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[06], CreationDate = DateTime.Now, Description = "توضیح فایل 06", Name = "File06", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[07], CreationDate = DateTime.Now, Description = "توضیح فایل 07", Name = "File07", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[08], CreationDate = DateTime.Now, Description = "توضیح فایل 08", Name = "File08", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[09], CreationDate = DateTime.Now, Description = "توضیح فایل 09", Name = "File09", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[10], CreationDate = DateTime.Now, Description = "توضیح فایل 10", Name = "File10", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[11], CreationDate = DateTime.Now, Description = "توضیح فایل 11", Name = "File11", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[12], CreationDate = DateTime.Now, Description = "توضیح فایل 12", Name = "File12", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[13], CreationDate = DateTime.Now, Description = "توضیح فایل 13", Name = "File13", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[14], CreationDate = DateTime.Now, Description = "توضیح فایل 14", Name = "File14", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[15], CreationDate = DateTime.Now, Description = "توضیح فایل 15", Name = "File15", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[16], CreationDate = DateTime.Now, Description = "توضیح فایل 16", Name = "File16", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[17], CreationDate = DateTime.Now, Description = "توضیح فایل 17", Name = "File17", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[18], CreationDate = DateTime.Now, Description = "توضیح فایل 18", Name = "File18", FileTypeId = 1, IsDeleted = false },
                    new BaseDataEntities.File { Id = guid[19], CreationDate = DateTime.Now, Description = "توضیح فایل 19", Name = "File19", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 1 },
                    new BaseDataEntities.File { Id = guid[20], CreationDate = DateTime.Now, Description = "توضیح فایل 20", Name = "File20", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 2 },
                    new BaseDataEntities.File { Id = guid[21], CreationDate = DateTime.Now, Description = "توضیح فایل 21", Name = "File21", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 3 },
                    new BaseDataEntities.File { Id = guid[22], CreationDate = DateTime.Now, Description = "توضیح فایل 22", Name = "File22", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 4 },
                    new BaseDataEntities.File { Id = guid[23], CreationDate = DateTime.Now, Description = "توضیح فایل 23", Name = "File23", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 5 },
                    new BaseDataEntities.File { Id = guid[24], CreationDate = DateTime.Now, Description = "توضیح فایل 24", Name = "File24", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 6 },
                    new BaseDataEntities.File { Id = guid[25], CreationDate = DateTime.Now, Description = "توضیح فایل 25", Name = "File25", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 7 },
                    new BaseDataEntities.File { Id = guid[26], CreationDate = DateTime.Now, Description = "توضیح فایل 26", Name = "File26", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 8 },
                    new BaseDataEntities.File { Id = guid[27], CreationDate = DateTime.Now, Description = "توضیح فایل 27", Name = "File27", FileTypeId = 1, IsDeleted = false, ExpertServiceId = 9 }
                    );
            });
            modelBuilder.Entity<Comment>(entity =>
                        {
                            entity.HasIndex(e => e.ExpertServiceId);
                            entity.HasIndex(e => e.CustomerId);
                            entity.HasData(
                                new Comment { Id = 1, CustomerId = 1, ExpertServiceId = 1, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 1 برای سرویس-متخصص شماره 1", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 2, CustomerId = 2, ExpertServiceId = 2, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 2 برای سرویس-متخصص شماره 2", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 3, CustomerId = 3, ExpertServiceId = 3, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 3 برای سرویس-متخصص شماره 3", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 4, CustomerId = 4, ExpertServiceId = 4, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 4 برای سرویس-متخصص شماره 4", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 5, CustomerId = 5, ExpertServiceId = 5, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 5 برای سرویس-متخصص شماره 5", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 6, CustomerId = 6, ExpertServiceId = 6, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 6 برای سرویس-متخصص شماره 6", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 7, CustomerId = 7, ExpertServiceId = 7, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 7 برای سرویس-متخصص شماره 7", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 8, CustomerId = 8, ExpertServiceId = 8, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 8 برای سرویس-متخصص شماره 8", Text = "متن", LikeCount = 1, DislikeCount = 1 },
                                new Comment { Id = 9, CustomerId = 9, ExpertServiceId = 9, IsConfirmed = true, SubmitDate = DateTime.Now, Title = "کامنت مشتری 9 برای سرویس-متخصص شماره 9", Text = "متن", LikeCount = 1, DislikeCount = 1 }
                                );
                        });
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasIndex(e => e.EvaluationTitleId);
                entity.HasIndex(e => e.PastWorkId);
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasOne(p => p.EvaluationTitle).WithMany().HasForeignKey(d => d.EvaluationTitleId);
                entity.HasData(
                    new Evaluation { Id = 1, EvaluationTitleId = 1, ExpertServiceId = 1, PastWorkId = 1, Score = 2 },
                    new Evaluation { Id = 2, EvaluationTitleId = 1, ExpertServiceId = 2, PastWorkId = 2, Score = 2 },
                    new Evaluation { Id = 3, EvaluationTitleId = 1, ExpertServiceId = 3, PastWorkId = 3, Score = 2 },
                    new Evaluation { Id = 4, EvaluationTitleId = 1, ExpertServiceId = 4, PastWorkId = 4, Score = 2 },
                    new Evaluation { Id = 5, EvaluationTitleId = 1, ExpertServiceId = 5, PastWorkId = 5, Score = 2 },
                    new Evaluation { Id = 6, EvaluationTitleId = 1, ExpertServiceId = 6, PastWorkId = 6, Score = 2 },
                    new Evaluation { Id = 7, EvaluationTitleId = 1, ExpertServiceId = 7, PastWorkId = 7, Score = 2 },
                    new Evaluation { Id = 8, EvaluationTitleId = 1, ExpertServiceId = 8, PastWorkId = 8, Score = 2 },
                    new Evaluation { Id = 9, EvaluationTitleId = 1, ExpertServiceId = 9, PastWorkId = 9, Score = 2 }
                    );
            });
            modelBuilder.Entity<PastWork>(entity =>
            {
                entity.HasIndex(e => e.ExpertServiceId);
                entity.HasIndex(e => e.CustomerId);
                entity.HasMany(p => p.Evaluations).WithOne(d => d.PastWork).HasForeignKey(d => d.PastWorkId).OnDelete(DeleteBehavior.NoAction);
                entity.HasData(
                    new PastWork { Id = 1, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 100000, CustomerId = 1, ExpertServiceId = 1 },
                    new PastWork { Id = 2, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 200000, CustomerId = 2, ExpertServiceId = 2 },
                    new PastWork { Id = 3, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 300000, CustomerId = 3, ExpertServiceId = 3 },
                    new PastWork { Id = 4, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 400000, CustomerId = 4, ExpertServiceId = 4 },
                    new PastWork { Id = 5, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 500000, CustomerId = 5, ExpertServiceId = 5 },
                    new PastWork { Id = 6, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 600000, CustomerId = 6, ExpertServiceId = 6 },
                    new PastWork { Id = 7, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 700000, CustomerId = 7, ExpertServiceId = 7 },
                    new PastWork { Id = 8, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 800000, CustomerId = 8, ExpertServiceId = 8 },
                    new PastWork { Id = 9, ComplitionDate = DateTime.Now + TimeSpan.FromDays(-2), IsDeleted = false, Price = 900000, CustomerId = 9, ExpertServiceId = 9 }
                    );
            });
            modelBuilder.Entity<Tender>(entity =>
            {
                entity.HasIndex(e => e.ExpertId);
                entity.HasIndex(e => e.OrderId);
                entity.HasOne(p => p.Order).WithMany(d => d.Tenders).HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasData(
                    new Tender { Id = 1, ExpertId = 1, OrderId = 1, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 2, ExpertId = 2, OrderId = 2, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 3, ExpertId = 3, OrderId = 3, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 4, ExpertId = 4, OrderId = 4, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 5, ExpertId = 5, OrderId = 5, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 6, ExpertId = 6, OrderId = 6, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 7, ExpertId = 7, OrderId = 7, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 8, ExpertId = 8, OrderId = 8, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false },
                    new Tender { Id = 9, ExpertId = 9, OrderId = 9, Price = 100000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(3), StartDate = DateTime.Now + TimeSpan.FromDays(1), Accepted = false }
                    );
            });
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(p => p.ImageFile).WithOne().HasForeignKey<Service>(p => p.ImageFileId);
                entity.HasMany(p => p.ExpertServices).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);
                entity.HasMany(p => p.ServiceFiles).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);
                entity.HasData(
                    new Service { Id = 1, CreationDate = DateTime.Now, Description = "توضیح سرویس 1", ImageFileId = guid[10], IsActive = true, IsDeleted = false, Name = "سرویس 1", Price = 100000 },
                    new Service { Id = 2, CreationDate = DateTime.Now, Description = "توضیح سرویس 2", ImageFileId = guid[11], IsActive = true, IsDeleted = false, Name = "سرویس 2", Price = 100000 },
                    new Service { Id = 3, CreationDate = DateTime.Now, Description = "توضیح سرویس 3", ImageFileId = guid[12], IsActive = true, IsDeleted = false, Name = "سرویس 3", ParentServiceId = 1, Price = 100000 },
                    new Service { Id = 4, CreationDate = DateTime.Now, Description = "توضیح سرویس 4", ImageFileId = guid[13], IsActive = true, IsDeleted = false, Name = "سرویس 4", ParentServiceId = 1, Price = 100000 },
                    new Service { Id = 5, CreationDate = DateTime.Now, Description = "توضیح سرویس 5", ImageFileId = guid[14], IsActive = true, IsDeleted = false, Name = "سرویس 5", ParentServiceId = 1, Price = 100000 },
                    new Service { Id = 6, CreationDate = DateTime.Now, Description = "توضیح سرویس 6", ImageFileId = guid[15], IsActive = true, IsDeleted = false, Name = "سرویس 6", ParentServiceId = 2, Price = 100000 },
                    new Service { Id = 7, CreationDate = DateTime.Now, Description = "توضیح سرویس 7", ImageFileId = guid[16], IsActive = true, IsDeleted = false, Name = "سرویس 7", ParentServiceId = 2, Price = 100000 },
                    new Service { Id = 8, CreationDate = DateTime.Now, Description = "توضیح سرویس 8", ImageFileId = guid[17], IsActive = true, IsDeleted = false, Name = "سرویس 8", ParentServiceId = 2, Price = 100000 },
                    new Service { Id = 9, CreationDate = DateTime.Now, Description = "توضیح سرویس 9", ImageFileId = guid[18], IsActive = true, IsDeleted = false, Name = "سرویس 9", ParentServiceId = 2, Price = 100000 }
                    );
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasMany(p => p.Comments).WithOne(d => d.Customer).HasForeignKey(d => d.CustomerId);
                entity.HasMany(p => p.Orders).WithOne(d => d.Customer).HasForeignKey(d => d.CustomerId);
                entity.HasMany(p => p.PastWorks).WithOne(d => d.Customer).HasForeignKey(d => d.CustomerId);
                entity.HasData(
                    new Customer { Id = 1, Address = "", AppUserId = 10 },
                    new Customer { Id = 2, Address = "", AppUserId = 11 },
                    new Customer { Id = 3, Address = "", AppUserId = 12 },
                    new Customer { Id = 4, Address = "", AppUserId = 13 },
                    new Customer { Id = 5, Address = "", AppUserId = 14 },
                    new Customer { Id = 6, Address = "", AppUserId = 15 },
                    new Customer { Id = 7, Address = "", AppUserId = 16 },
                    new Customer { Id = 8, Address = "", AppUserId = 17 },
                    new Customer { Id = 9, Address = "", AppUserId = 18 }
                    );
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);
                entity.HasIndex(e => e.OrderStateId);
                entity.HasOne(p => p.OrderState).WithMany().HasForeignKey(d => d.OrderStateId);
                entity.HasData(
                    new Order { Id = 1, CustomerId = 1, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 1 },
                    new Order { Id = 2, CustomerId = 2, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 2 },
                    new Order { Id = 3, CustomerId = 3, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 3 },
                    new Order { Id = 4, CustomerId = 4, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 4 },
                    new Order { Id = 5, CustomerId = 5, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 5 },
                    new Order { Id = 6, CustomerId = 6, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 6 },
                    new Order { Id = 7, CustomerId = 7, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 7 },
                    new Order { Id = 8, CustomerId = 8, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 8 },
                    new Order { Id = 9, CustomerId = 9, OrderStateId = 1, IsDeleted = false, RegisterDate = DateTime.Now, ServiceId = 9 }
                    );
            });
            modelBuilder.Entity<FileType>(entity => entity.HasData(
                new FileType { Id = 1, Name = "Image", IsDeleted = false, Extention = "jpg" }
                ));
            modelBuilder.Entity<OrderState>(entity => entity.HasData(
                new OrderState { Id = 1, Name = "در حال بررسی", IsDeleted = false },
                new OrderState { Id = 2, Name = "منتظر پیشنهاد متخصص", IsDeleted = false },
                new OrderState { Id = 3, Name = "منتظر انتخاب متخصص", IsDeleted = false },
                new OrderState { Id = 4, Name = "منتظر آمدن متخصص", IsDeleted = false }
                ));
            modelBuilder.Entity<EvaluationTitle>(entity => entity.HasData(
                new EvaluationTitle { Id = 1, Name = "کیفیت", IsDeleted = false }
                ));
        }
    }
}
