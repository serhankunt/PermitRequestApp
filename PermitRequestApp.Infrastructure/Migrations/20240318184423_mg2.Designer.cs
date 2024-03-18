﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PermitRequestApp.Infrastructure.Context;

#nullable disable

namespace PermitRequestApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240318184423_mg2")]
    partial class mg2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PermitRequestApp.Domain.ADUsers.ADUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ADUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1"),
                            Email = "ozgetoksoz@gmail.com",
                            FirstName = "Özge",
                            LastName = "Toksöz",
                            UserType = 30
                        },
                        new
                        {
                            Id = new Guid("88204738-994b-4999-b752-78e071ba9d1f"),
                            Email = "serhankunt@gmail.com",
                            FirstName = "H. Serhan",
                            LastName = "Kunt",
                            ManagerId = new Guid("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1"),
                            UserType = 10
                        },
                        new
                        {
                            Id = new Guid("2a2e822c-b1cf-422f-a8ae-6307e0f03a77"),
                            Email = "betulkunt@gmail.com",
                            FirstName = "Betül",
                            LastName = "Kunt",
                            ManagerId = new Guid("88204738-994b-4999-b752-78e071ba9d1f"),
                            UserType = 20
                        });
                });

            modelBuilder.Entity("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CumulativeLeaveRequests", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.LeaveRequests.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("LeaveRequests", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.Notificationss.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CumulativeLeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CumulativeLeaveRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.ADUsers.ADUser", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.LeaveRequests.LeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AssignedUser");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.Notificationss.Notification", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", "CumulativeLeaveRequest")
                        .WithMany()
                        .HasForeignKey("CumulativeLeaveRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CumulativeLeaveRequest");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
