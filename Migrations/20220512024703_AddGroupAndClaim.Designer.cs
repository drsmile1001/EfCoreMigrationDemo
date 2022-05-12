﻿// <auto-generated />
using System;
using EfCoreMigrationDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreMigrationDemo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220512024703_AddGroupAndClaim")]
    partial class AddGroupAndClaim
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("ID");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("類型");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("值");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("名稱");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("信箱");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("暱稱");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.PersonGroup", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("群組ID");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("人員ID");

                    b.HasKey("GroupId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonGroup");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.Claim", b =>
                {
                    b.HasOne("EfCoreMigrationDemo.Entities.Person", "Person")
                        .WithMany("Claims")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.PersonGroup", b =>
                {
                    b.HasOne("EfCoreMigrationDemo.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreMigrationDemo.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EfCoreMigrationDemo.Entities.Person", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}