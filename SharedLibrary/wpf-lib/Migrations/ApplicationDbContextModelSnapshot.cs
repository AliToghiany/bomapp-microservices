﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wpf_lib.Context;

#nullable disable

namespace wpf_lib.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("wpf_lib.Entity.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("wpf_lib.Entity.ImageProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ImageProfiles");
                });

            modelBuilder.Entity("wpf_lib.Entity.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message_Id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ReplyMessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ToUserId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReplyMessageId");

                    b.HasIndex("ToUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("wpf_lib.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<long?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wpf_lib.Entity.File", b =>
                {
                    b.HasOne("wpf_lib.Entity.Message", null)
                        .WithMany("Files")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wpf_lib.Entity.ImageProfile", b =>
                {
                    b.HasOne("wpf_lib.Entity.User", "User")
                        .WithMany("ImageProfiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wpf_lib.Entity.Message", b =>
                {
                    b.HasOne("wpf_lib.Entity.Message", "ReplyMessage")
                        .WithMany()
                        .HasForeignKey("ReplyMessageId");

                    b.HasOne("wpf_lib.Entity.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");

                    b.HasOne("wpf_lib.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ReplyMessage");

                    b.Navigation("ToUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wpf_lib.Entity.User", b =>
                {
                    b.HasOne("wpf_lib.Entity.User", null)
                        .WithMany("Message")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("wpf_lib.Entity.Message", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("wpf_lib.Entity.User", b =>
                {
                    b.Navigation("ImageProfiles");

                    b.Navigation("Message");
                });
#pragma warning restore 612, 618
        }
    }
}
