﻿// <auto-generated />
using System;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Server.Data.Migrations
{
    [DbContext(typeof(AnthemGoldPwaDbContext))]
    partial class AnthemGoldPwaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Entities.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Version");

                    b.HasKey("ApplicationId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Server.Entities.AssetDefinition", b =>
                {
                    b.Property<int>("AssetDefinitionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("AssetDefinitionId");

                    b.ToTable("AssetDefinition");
                });

            modelBuilder.Entity("Server.Entities.MetricDefinition", b =>
                {
                    b.Property<int>("MetricDefinitionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetDefinitionId");

                    b.Property<string>("Default");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Regex");

                    b.Property<string>("SampleValue");

                    b.Property<string>("UnitOfMeasure");

                    b.HasKey("MetricDefinitionId");

                    b.HasIndex("AssetDefinitionId");

                    b.ToTable("MetricDefinition");
                });

            modelBuilder.Entity("Server.Entities.MetricDefinition", b =>
                {
                    b.HasOne("Server.Entities.AssetDefinition")
                        .WithMany("Metrics")
                        .HasForeignKey("AssetDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
