﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211213100559_UserProjectsEntityAdded")]
    partial class UserProjectsEntityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.BoundingBox", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Angle")
                        .HasColumnType("float");

                    b.Property<int>("BoundingBoxNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<decimal>("X1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("X2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y2")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("BoundingBox");
                });

            modelBuilder.Entity("API.Entities.LineSegment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolygonId")
                        .HasColumnType("int");

                    b.Property<int>("PolygonNo")
                        .HasColumnType("int");

                    b.Property<decimal>("X1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("X2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y2")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PolygonId");

                    b.ToTable("LineSegments");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UserProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProjectId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("API.Entities.Polygon", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EndX")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EndY")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("PolygonNo")
                        .HasColumnType("int");

                    b.Property<decimal>("StartX")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StartY")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Polygons");
                });

            modelBuilder.Entity("API.Entities.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("API.Entities.BoundingBox", b =>
                {
                    b.HasOne("API.Entities.Photo", null)
                        .WithMany("BoundingBoxes")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.LineSegment", b =>
                {
                    b.HasOne("API.Entities.Polygon", null)
                        .WithMany("LineSegments")
                        .HasForeignKey("PolygonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.HasOne("API.Entities.UserProject", null)
                        .WithMany("Photos")
                        .HasForeignKey("UserProjectId");
                });

            modelBuilder.Entity("API.Entities.Polygon", b =>
                {
                    b.HasOne("API.Entities.Photo", null)
                        .WithMany("Polygons")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.UserProject", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany("UserProjects")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Navigation("BoundingBoxes");

                    b.Navigation("Polygons");
                });

            modelBuilder.Entity("API.Entities.Polygon", b =>
                {
                    b.Navigation("LineSegments");
                });

            modelBuilder.Entity("API.Entities.UserProject", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
