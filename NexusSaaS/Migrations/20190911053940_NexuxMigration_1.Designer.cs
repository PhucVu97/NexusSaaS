﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NexusSaaS.Data;

namespace NexusSaaS.Migrations
{
    [DbContext(typeof(NexusSaaSDbContext))]
    [Migration("20190911053940_NexuxMigration_1")]
    partial class NexuxMigration_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NexusSaaS.Entity.FeatureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Description");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("features");
                });

            modelBuilder.Entity("NexusSaaS.Entity.MessageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Subject");

                    b.Property<string>("UserEntityId");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("message");
                });

            modelBuilder.Entity("NexusSaaS.Entity.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("NexusSaaS.Entity.MessageEntity", b =>
                {
                    b.HasOne("NexusSaaS.Entity.UserEntity", "UserEntity")
                        .WithMany("MessageEntitys")
                        .HasForeignKey("UserEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}