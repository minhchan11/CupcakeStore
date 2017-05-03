using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GitTrio.Models;

namespace GitTrio.Migrations
{
    [DbContext(typeof(GitTrioContext))]
    partial class GitTrioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
        }
    }
}
