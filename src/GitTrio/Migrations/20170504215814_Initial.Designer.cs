using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GitTrio.Models;

namespace GitTrio.Migrations
{
    [DbContext(typeof(GitTrioContext))]
    [Migration("20170504215814_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitTrio.Models.Cupcake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cake");

                    b.Property<string>("Description");

                    b.Property<string>("Frosting");

                    b.Property<string>("ImgUrl");

                    b.Property<int>("Inventory");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("Topping");

                    b.HasKey("Id");

                    b.ToTable("Cupcakes");
                });

            modelBuilder.Entity("GitTrio.Models.CupcakeUser", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("UserId");

                    b.Property<int?>("CupcakeId");

                    b.HasKey("Id", "UserId");

                    b.HasIndex("CupcakeId");

                    b.HasIndex("UserId");

                    b.ToTable("CupcakesUsers");
                });

            modelBuilder.Entity("GitTrio.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GitTrio.Models.CupcakeUser", b =>
                {
                    b.HasOne("GitTrio.Models.Cupcake", "Cupcake")
                        .WithMany("CupcakesUsers")
                        .HasForeignKey("CupcakeId");

                    b.HasOne("GitTrio.Models.User", "User")
                        .WithMany("CupcakesUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
