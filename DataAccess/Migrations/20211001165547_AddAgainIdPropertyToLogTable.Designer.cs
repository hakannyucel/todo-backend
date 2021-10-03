﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211001165547_AddAgainIdPropertyToLogTable")]
    partial class AddAgainIdPropertyToLogTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Concrete.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Audit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("audit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("detail");

                    b.HasKey("Id");

                    b.ToTable("logs");
                });

            modelBuilder.Entity("Entities.Concrete.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("tag_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("tag_name");

                    b.HasKey("Id");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("Entities.Concrete.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("todo_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Datetime")
                        .HasColumnName("todo_created_date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("todo_description");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("Datetime")
                        .HasColumnName("todo_due_date");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("todo_task");

                    b.HasKey("Id");

                    b.ToTable("todos");
                });

            modelBuilder.Entity("Entities.Concrete.TodoTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("todo_tag_id");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("todo_tag_tag_id");

                    b.Property<Guid>("TodoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("todo_tag_todo_id");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TodoId");

                    b.ToTable("todo_tags");
                });

            modelBuilder.Entity("Entities.Concrete.TodoTag", b =>
                {
                    b.HasOne("Entities.Concrete.Tag", "Tag")
                        .WithMany("TodoTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Todo", "Todo")
                        .WithMany("TodoTags")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("Entities.Concrete.Tag", b =>
                {
                    b.Navigation("TodoTags");
                });

            modelBuilder.Entity("Entities.Concrete.Todo", b =>
                {
                    b.Navigation("TodoTags");
                });
#pragma warning restore 612, 618
        }
    }
}
