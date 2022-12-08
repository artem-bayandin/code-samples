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
    [Migration("20210819111502_a longer quiz added")]
    partial class alongerquizadded
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
                            Id = 12,
                            Name = "Multi nodes test",
                            Root = "{\"Id\":13,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":14,\"Text\":\"You clicked 'yes', great. That's the end\"}},{\"Relation\":\"no\",\"Node\":{\"Id\":15,\"Text\":\"Yeah! Thanks for NOT playing!\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":16,\"Text\":\"Hmm... Are you a human?\",\"Children\":[{\"Relation\":\"not sure\",\"Node\":{\"Id\":17,\"Text\":\"You have chosen the right one.\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":18,\"Text\":\"You have chosen the left one.\"}}]}}]}"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Long Quiz",
                            Root = "{\"Id\":20,\"Text\":\"How are you?\",\"Children\":[{\"Relation\":\"fine\",\"Node\":{\"Id\":21,\"Text\":\"Not bad, not bad. Are you waiting for a weekend to have a rest?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":1,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"drink beer\",\"Node\":{\"Id\":2,\"Text\":\"Dark or light?\",\"Children\":[{\"Relation\":\"dark\",\"Node\":{\"Id\":3,\"Text\":\"I will call you 'Dark Knight' now)\"}},{\"Relation\":\"light\",\"Node\":{\"Id\":4,\"Text\":\"Light is for girls, urgh... I have no more questions.\"}},{\"Relation\":\"Budweiser\",\"Node\":{\"Id\":5,\"Text\":\"Great choice! Feel free to fill you tanks!\"}}]}},{\"Relation\":\"do sports\",\"Node\":{\"Id\":6,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":7,\"Text\":\"Ha-ha! Okay, have a rest.\"}},{\"Relation\":\"Nike\",\"Node\":{\"Id\":8,\"Text\":\"Just do it!\"}}]}},{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":9,\"Text\":\"Ha-ha! Okay, have a rest.\"}}]}},{\"Relation\":\"no\",\"Node\":{\"Id\":10,\"Text\":\"No? So you have no plan to feel better and answer 'brilliant' next time?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":11,\"Text\":\"Okay. Bye.\"}}]}}]}},{\"Relation\":\"brilliant\",\"Node\":{\"Id\":22,\"Text\":\"Great to hear! But I have not prepared another questions to you, rather than from the first option. So, are you waiting for a weekend to have a rest?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":1,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"drink beer\",\"Node\":{\"Id\":2,\"Text\":\"Dark or light?\",\"Children\":[{\"Relation\":\"dark\",\"Node\":{\"Id\":3,\"Text\":\"I will call you 'Dark Knight' now)\"}},{\"Relation\":\"light\",\"Node\":{\"Id\":4,\"Text\":\"Light is for girls, urgh... I have no more questions.\"}},{\"Relation\":\"Budweiser\",\"Node\":{\"Id\":5,\"Text\":\"Great choice! Feel free to fill you tanks!\"}}]}},{\"Relation\":\"do sports\",\"Node\":{\"Id\":6,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":7,\"Text\":\"Ha-ha! Okay, have a rest.\"}},{\"Relation\":\"Nike\",\"Node\":{\"Id\":8,\"Text\":\"Just do it!\"}}]}},{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":9,\"Text\":\"Ha-ha! Okay, have a rest.\"}}]}},{\"Relation\":\"no\",\"Node\":{\"Id\":10,\"Text\":\"No? So you have no plan to feel better and answer 'brilliant' next time?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":11,\"Text\":\"Okay. Bye.\"}}]}}]}}]}"
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