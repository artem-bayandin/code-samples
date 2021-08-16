﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20210816131114_Quiz answers added")]
    partial class Quizanswersadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Persistence.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Root")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Yes / No",
                            Root = "{\"Id\":3,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":4,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":5,\"Text\":\"Yeah! Thanks for not playing!\"}}]}"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Multi nodes",
                            Root = "{\"Id\":7,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":8,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":9,\"Text\":\"Yeah! Thanks for not playing!\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":10,\"Text\":\"Hmm... Are you a human?\",\"Children\":[{\"Relation\":\"not sure\",\"Node\":{\"Id\":11,\"Text\":\"You have chosen the right one.\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":12,\"Text\":\"You have chosen the left one.\"}}]}}]}"
                        });
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.QuizUserAnswer", b =>
                {
                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SelectedNodes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.QuizUserAnswer", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.Quiz", "Quiz")
                        .WithMany("Answers")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Persistence.Entities.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.Quiz", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.User", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
