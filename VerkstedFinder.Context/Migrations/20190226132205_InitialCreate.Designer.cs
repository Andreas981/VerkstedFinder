﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerkstedFinder.Context;

namespace VerkstedFinder.Context.Migrations
{
    [DbContext(typeof(AndremiContext))]
    [Migration("20190226132205_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VerkstedFinder.Model.Permission", b =>
                {
                    b.Property<int>("PermId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Perm_name");

                    b.Property<int?>("RoleId");

                    b.HasKey("PermId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Poststed", b =>
                {
                    b.Property<int>("Postnr")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PoststedName");

                    b.HasKey("Postnr");

                    b.ToTable("Poststeds");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("VerkstedFinder.Model.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_firstname");

                    b.Property<string>("User_lastname");

                    b.Property<string>("User_username");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Workshop", b =>
                {
                    b.Property<int>("Ws_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Postnr1");

                    b.Property<string>("Ws_address");

                    b.Property<string>("Ws_name");

                    b.Property<string>("Ws_string");

                    b.HasKey("Ws_id");

                    b.HasIndex("Postnr1");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Permission", b =>
                {
                    b.HasOne("VerkstedFinder.Model.Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Workshop", b =>
                {
                    b.HasOne("VerkstedFinder.Model.Poststed", "Postnr")
                        .WithMany()
                        .HasForeignKey("Postnr1");
                });
#pragma warning restore 612, 618
        }
    }
}
