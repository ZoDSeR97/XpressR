﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XpressR.Server.Models;

#nullable disable

namespace XpressR.Server.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("XpressR.Shared.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AmenityId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("XpressR.Shared.HasAmenities", b =>
                {
                    b.Property<int>("HasAmenitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("HasAmenitiesId");

                    b.HasIndex("AmenityId");

                    b.HasIndex("PropertyId");

                    b.ToTable("HasAmenities");
                });

            modelBuilder.Entity("XpressR.Shared.HasTypes", b =>
                {
                    b.Property<int>("HasTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("HasTypesId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("HasTypes");
                });

            modelBuilder.Entity("XpressR.Shared.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Room")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("SharedRoom")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("XpressR.Shared.RSVP", b =>
                {
                    b.Property<int>("RSVPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RSVPId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("RSVP");
                });

            modelBuilder.Entity("XpressR.Shared.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RSVPId")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ReviewId");

                    b.HasIndex("RSVPId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("XpressR.Shared.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoomTypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("XpressR.Shared.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("XpressR.Shared.HasAmenities", b =>
                {
                    b.HasOne("XpressR.Shared.Amenity", "Amenity")
                        .WithMany("Properties")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XpressR.Shared.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("XpressR.Shared.HasTypes", b =>
                {
                    b.HasOne("XpressR.Shared.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XpressR.Shared.RoomType", "RoomType")
                        .WithMany("Properties")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("XpressR.Shared.Property", b =>
                {
                    b.HasOne("XpressR.Shared.User", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("XpressR.Shared.RSVP", b =>
                {
                    b.HasOne("XpressR.Shared.Property", "Property")
                        .WithMany("Guests")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XpressR.Shared.User", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("XpressR.Shared.Review", b =>
                {
                    b.HasOne("XpressR.Shared.RSVP", "PastTrip")
                        .WithOne("Review")
                        .HasForeignKey("XpressR.Shared.Review", "RSVPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PastTrip");
                });

            modelBuilder.Entity("XpressR.Shared.Amenity", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("XpressR.Shared.Property", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("XpressR.Shared.RSVP", b =>
                {
                    b.Navigation("Review");
                });

            modelBuilder.Entity("XpressR.Shared.RoomType", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("XpressR.Shared.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
