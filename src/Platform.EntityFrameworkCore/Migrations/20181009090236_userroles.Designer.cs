﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platform.EntityFrameworkCore;

namespace Platform.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    [Migration("20181009090236_userroles")]
    partial class userroles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Platform.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateTime");

                    b.Property<bool>("IsDefaultRole");

                    b.Property<int>("IsDelete");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("IsStaticRole");

                    b.Property<string>("ModifyName")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifyTime");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Platform.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(30);

                    b.Property<string>("CreateName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(30);

                    b.Property<string>("Header")
                        .HasMaxLength(100);

                    b.Property<int>("IsDelete");

                    b.Property<string>("ModifyName")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifyTime");

                    b.Property<string>("NiceName")
                        .HasMaxLength(20);

                    b.Property<string>("OpenID")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("QQ")
                        .HasMaxLength(30);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Status");

                    b.Property<string>("WeiXin")
                        .HasMaxLength(30);

                    b.Property<string>("WorkNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Platform.Entity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}