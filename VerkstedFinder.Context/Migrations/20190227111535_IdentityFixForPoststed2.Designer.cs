﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerkstedFinder.Context;

namespace VerkstedFinder.Context.Migrations
{
    [DbContext(typeof(AndremiContext))]
    [Migration("20190227111535_IdentityFixForPoststed2")]
    partial class IdentityFixForPoststed2
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

                    b.Property<string>("Perm_name")
                        .IsRequired();

                    b.HasKey("PermId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Poststed", b =>
                {
                    b.Property<int>("Postnr")
                        .ValueGeneratedOnAdd()
                        .HasComputedColumnSql("SET IDENTITY_INSERT ON");

                    b.Property<string>("PoststedName")
                        .IsRequired();

                    b.HasKey("Postnr");

                    b.ToTable("Poststeds");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("VerkstedFinder.Model.RolePermission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("PermId");

                    b.HasKey("RoleId", "PermId");

                    b.HasIndex("PermId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("VerkstedFinder.Model.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_firstname")
                        .IsRequired();

                    b.Property<string>("User_lastname")
                        .IsRequired();

                    b.Property<int>("User_roleRoleId");

                    b.Property<string>("User_username")
                        .IsRequired();

                    b.HasKey("User_id");

                    b.HasIndex("User_roleRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VerkstedFinder.Model.Workshop", b =>
                {
                    b.Property<int>("Ws_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Postnr1");

                    b.Property<string>("Ws_address")
                        .IsRequired();

                    b.Property<string>("Ws_name")
                        .IsRequired();

                    b.HasKey("Ws_id");

                    b.HasIndex("Postnr1");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("VerkstedFinder.Model.RolePermission", b =>
                {
                    b.HasOne("VerkstedFinder.Model.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VerkstedFinder.Model.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VerkstedFinder.Model.User", b =>
                {
                    b.HasOne("VerkstedFinder.Model.Role", "User_role")
                        .WithMany()
                        .HasForeignKey("User_roleRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VerkstedFinder.Model.Workshop", b =>
                {
                    b.HasOne("VerkstedFinder.Model.Poststed", "Postnr")
                        .WithMany()
                        .HasForeignKey("Postnr1")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
