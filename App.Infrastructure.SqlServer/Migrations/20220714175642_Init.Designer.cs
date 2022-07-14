﻿// <auto-generated />
using System;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.SqlServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220714175642_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.Domain.Core.BaseData.Entities.FileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("ExpertServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EvaluationTitleId")
                        .HasColumnType("int");

                    b.Property<int>("ExpertServiceId")
                        .HasColumnType("int");

                    b.Property<int>("PastWorkId")
                        .HasColumnType("int");

                    b.Property<short?>("Score")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationTitleId");

                    b.HasIndex("ExpertServiceId");

                    b.HasIndex("PastWorkId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.EvaluationTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EvaluationTitles");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.ExpertService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ExpertServices");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.ExpertServiceFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ExpertServiceId")
                        .HasColumnType("int");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameWithExtention")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExpertServiceId");

                    b.HasIndex("FileTypeId");

                    b.ToTable("ExpertServiceFiles");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.PastWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ComplitionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpertServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("PastWorks");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("RequiredTime")
                        .HasColumnType("time");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("OrderId");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("App.Domain.Core.Operator.Entities.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("App.Domain.Core.Service.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentSrviceId")
                        .HasColumnType("int");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("App.Domain.Core.Service.Entities.ServiceFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameWithExtention")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceFiles");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderStateId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.OrderState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OrderStates");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Comment", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.ExpertService", "ExpertService")
                        .WithMany("Comments")
                        .HasForeignKey("ExpertServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.User.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpertService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Evaluation", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.EvaluationTitle", "EvaluationTitle")
                        .WithMany("Evaluations")
                        .HasForeignKey("EvaluationTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Expert.Entities.ExpertService", "ExpertService")
                        .WithMany("Evaluations")
                        .HasForeignKey("ExpertServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Expert.Entities.PastWork", "PastWork")
                        .WithMany("Evaluations")
                        .HasForeignKey("PastWorkId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EvaluationTitle");

                    b.Navigation("ExpertService");

                    b.Navigation("PastWork");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.ExpertService", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.Expert", "Expert")
                        .WithMany("ExpertServices")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Service.Entities.Service", "Service")
                        .WithMany("ExpertServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.ExpertServiceFile", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.ExpertService", "ExpertService")
                        .WithMany("expertServiceFiles")
                        .HasForeignKey("ExpertServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.BaseData.Entities.FileType", "FileType")
                        .WithMany("ExpertServiceFiles")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpertService");

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.PastWork", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.ExpertService", "ExpertService")
                        .WithMany("PastWorks")
                        .HasForeignKey("ExpertServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.User.Entities.User", "User")
                        .WithMany("PastWorks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpertService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Tender", b =>
                {
                    b.HasOne("App.Domain.Core.Expert.Entities.Expert", "Expert")
                        .WithMany("Tenders")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.User.Entities.Order", "Order")
                        .WithMany("Tenders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Domain.Core.Service.Entities.Service", b =>
                {
                    b.HasOne("App.Domain.Core.Service.Entities.Service", "ParentService")
                        .WithMany()
                        .HasForeignKey("ParentServiceId");

                    b.Navigation("ParentService");
                });

            modelBuilder.Entity("App.Domain.Core.Service.Entities.ServiceFile", b =>
                {
                    b.HasOne("App.Domain.Core.BaseData.Entities.FileType", "FileType")
                        .WithMany("ServiceFiles")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Service.Entities.Service", "Service")
                        .WithMany("ServiceFiles")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileType");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.Order", b =>
                {
                    b.HasOne("App.Domain.Core.User.Entities.OrderState", "OrderState")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Service.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.User.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderState");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.BaseData.Entities.FileType", b =>
                {
                    b.Navigation("ExpertServiceFiles");

                    b.Navigation("ServiceFiles");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.EvaluationTitle", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.Expert", b =>
                {
                    b.Navigation("ExpertServices");

                    b.Navigation("Tenders");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.ExpertService", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Evaluations");

                    b.Navigation("PastWorks");

                    b.Navigation("expertServiceFiles");
                });

            modelBuilder.Entity("App.Domain.Core.Expert.Entities.PastWork", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("App.Domain.Core.Service.Entities.Service", b =>
                {
                    b.Navigation("ExpertServices");

                    b.Navigation("ServiceFiles");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.Order", b =>
                {
                    b.Navigation("Tenders");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.OrderState", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("App.Domain.Core.User.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");

                    b.Navigation("PastWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
