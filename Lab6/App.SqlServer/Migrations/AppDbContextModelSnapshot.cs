﻿// <auto-generated />
using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.SqlServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Asset", b =>
                {
                    b.Property<Guid>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AssetTypeCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SizeCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AssetId");

                    b.HasIndex("AssetTypeCode");

                    b.HasIndex("SizeCode");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("App.Models.AssetsLifeCycleEvent", b =>
                {
                    b.Property<int>("AssetLifeCycleEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetLifeCycleEventId"));

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("LifeCycleCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AssetLifeCycleEventId");

                    b.HasIndex("AssetId");

                    b.HasIndex("LifeCycleCode");

                    b.HasIndex("LocationId");

                    b.HasIndex("PartyId");

                    b.HasIndex("StatusCode");

                    b.ToTable("AssetsLifeCycleEvents");
                });

            modelBuilder.Entity("App.Models.LifeCyclePhase", b =>
                {
                    b.Property<string>("LifeCycleCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LifeCycleDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LifeCycleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LifeCycleCode");

                    b.ToTable("LifeCyclePhases");
                });

            modelBuilder.Entity("App.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationDetails")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("App.Models.RefAssetCategory", b =>
                {
                    b.Property<string>("AssetCategoryCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AssetCategoryDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AssetCategoryCode");

                    b.ToTable("RefAssetCategories");
                });

            modelBuilder.Entity("App.Models.RefAssetSupertype", b =>
                {
                    b.Property<string>("AssetSupertypeCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AssetCategoryCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AssetSupertypeDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AssetSupertypeCode");

                    b.HasIndex("AssetCategoryCode");

                    b.ToTable("RefAssetSupertypes");
                });

            modelBuilder.Entity("App.Models.RefAssetType", b =>
                {
                    b.Property<string>("AssetTypeCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AssetSupertypeCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AssetTypeDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AssetTypeCode");

                    b.HasIndex("AssetSupertypeCode");

                    b.ToTable("RefAssetTypes");
                });

            modelBuilder.Entity("App.Models.RefSize", b =>
                {
                    b.Property<string>("SizeCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SizeDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SizeCode");

                    b.ToTable("RefSizes");
                });

            modelBuilder.Entity("App.Models.RefStatus", b =>
                {
                    b.Property<string>("StatusCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.HasKey("StatusCode");

                    b.ToTable("RefStatuses");
                });

            modelBuilder.Entity("App.Models.ResponsibleParty", b =>
                {
                    b.Property<Guid>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartyDetails")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PartyId");

                    b.ToTable("ResponsibleParties");
                });

            modelBuilder.Entity("App.Models.Asset", b =>
                {
                    b.HasOne("App.Models.RefAssetType", "RefAssetType")
                        .WithMany("Assets")
                        .HasForeignKey("AssetTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.RefSize", "RefSize")
                        .WithMany("Assets")
                        .HasForeignKey("SizeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetType");

                    b.Navigation("RefSize");
                });

            modelBuilder.Entity("App.Models.AssetsLifeCycleEvent", b =>
                {
                    b.HasOne("App.Models.Asset", "Asset")
                        .WithMany("AssetsLifeCycleEvents")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.LifeCyclePhase", "LifeCyclePhase")
                        .WithMany("AssetsLifeCycleEvents")
                        .HasForeignKey("LifeCycleCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Location", "Location")
                        .WithMany("AssetsLifeCycleEvents")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.ResponsibleParty", "ResponsibleParty")
                        .WithMany("AssetsLifeCycleEvents")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.RefStatus", "RefStatus")
                        .WithMany("AssetsLifeCycleEvents")
                        .HasForeignKey("StatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("LifeCyclePhase");

                    b.Navigation("Location");

                    b.Navigation("RefStatus");

                    b.Navigation("ResponsibleParty");
                });

            modelBuilder.Entity("App.Models.RefAssetSupertype", b =>
                {
                    b.HasOne("App.Models.RefAssetCategory", "RefAssetCategory")
                        .WithMany("RefAssetSupertypes")
                        .HasForeignKey("AssetCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetCategory");
                });

            modelBuilder.Entity("App.Models.RefAssetType", b =>
                {
                    b.HasOne("App.Models.RefAssetSupertype", "RefAssetSupertype")
                        .WithMany("RefAssetTypes")
                        .HasForeignKey("AssetSupertypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetSupertype");
                });

            modelBuilder.Entity("App.Models.Asset", b =>
                {
                    b.Navigation("AssetsLifeCycleEvents");
                });

            modelBuilder.Entity("App.Models.LifeCyclePhase", b =>
                {
                    b.Navigation("AssetsLifeCycleEvents");
                });

            modelBuilder.Entity("App.Models.Location", b =>
                {
                    b.Navigation("AssetsLifeCycleEvents");
                });

            modelBuilder.Entity("App.Models.RefAssetCategory", b =>
                {
                    b.Navigation("RefAssetSupertypes");
                });

            modelBuilder.Entity("App.Models.RefAssetSupertype", b =>
                {
                    b.Navigation("RefAssetTypes");
                });

            modelBuilder.Entity("App.Models.RefAssetType", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("App.Models.RefSize", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("App.Models.RefStatus", b =>
                {
                    b.Navigation("AssetsLifeCycleEvents");
                });

            modelBuilder.Entity("App.Models.ResponsibleParty", b =>
                {
                    b.Navigation("AssetsLifeCycleEvents");
                });
#pragma warning restore 612, 618
        }
    }
}