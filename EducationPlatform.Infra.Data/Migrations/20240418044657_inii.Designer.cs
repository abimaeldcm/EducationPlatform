﻿// <auto-generated />
using System;
using EducationPlatform.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationPlatform.Infra.Data.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    [Migration("20240418044657_inii")]
    partial class inii
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Blocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2024, 4, 18, 1, 46, 57, 417, DateTimeKind.Local).AddTicks(9633),
                            Description = "Description",
                            IdCourse = 1,
                            Name = "Instalção das ferramentas"
                        });
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SignatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SignatureId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cover = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.treinaweb.com.br%2Fblog%2Fcomo-instalar-o-csharp-e-nosso-primeiro-exemplo&psig=AOvVaw1j2JR7fNFScafseX_uX4qA&ust=1713292306049000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCPDhk67txIUDFQAAAAAdAAAAABAE",
                            CreationDate = new DateTime(2024, 4, 18, 1, 46, 57, 418, DateTimeKind.Local).AddTicks(2309),
                            Description = "Iniciando pelo básico do C#",
                            Name = "Introdução o C#",
                            SignatureId = 1
                        });
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.EntityRelational.UserLessonCompleted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FinishedLesson")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLesson")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLesson");

                    b.HasIndex("IdUser");

                    b.ToTable("UserLessonCompleted");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.EntityRelational.UserSignature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SignatureId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SignatureId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSignatures");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("LinkVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlockId = 1,
                            CreationDate = new DateTime(2024, 4, 18, 1, 46, 57, 418, DateTimeKind.Local).AddTicks(3973),
                            Description = "Descrição",
                            Duration = 600,
                            LinkVideo = "https://www.youtube.com/watch?v=PZ7HiQdT0Dw",
                            Name = "Visual Studio Code"
                        });
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.PaymentSignature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdExternalPayment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUserSignature")
                        .HasColumnType("int");

                    b.Property<string>("LinkPayment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ProcessingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUserSignature");

                    b.ToTable("PaymentSignatures");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Signature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Signatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 365,
                            IsActive = true,
                            Name = "Padrão"
                        });
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SignatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SignatureId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessLevel = 0,
                            Birthday = new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CPF = "06445661327",
                            Email = "abi@mail.com",
                            FullName = "abi",
                            IsActive = true,
                            Password = "123456789",
                            PhoneNumber = "86952258855",
                            SignatureId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccessLevel = 1,
                            Birthday = new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CPF = "12345678910",
                            Email = "joao@mail.com",
                            FullName = "nay",
                            IsActive = true,
                            Password = "123456789",
                            PhoneNumber = "987654321",
                            SignatureId = 1
                        });
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Block", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Course", "Course")
                        .WithMany("Block")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Course", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Signature", "Signature")
                        .WithMany("Courses")
                        .HasForeignKey("SignatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Signature");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.EntityRelational.UserLessonCompleted", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("IdLesson")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EducationPlatform.Domain.Entity.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.EntityRelational.UserSignature", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Signature", "Signature")
                        .WithMany()
                        .HasForeignKey("SignatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationPlatform.Domain.Entity.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Signature");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Lesson", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Block", "Block")
                        .WithMany("Lesson")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.PaymentSignature", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.EntityRelational.UserSignature", "UserSignature")
                        .WithMany()
                        .HasForeignKey("IdUserSignature")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSignature");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.UserEntity", b =>
                {
                    b.HasOne("EducationPlatform.Domain.Entity.Signature", "Signature")
                        .WithMany()
                        .HasForeignKey("SignatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Signature");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Block", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Course", b =>
                {
                    b.Navigation("Block");
                });

            modelBuilder.Entity("EducationPlatform.Domain.Entity.Signature", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
