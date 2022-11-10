﻿// <auto-generated />
using System;
using BackEnd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221011174437_AddpreviewTabel")]
    partial class AddpreviewTabel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("areas");
                });

            modelBuilder.Entity("BackEnd.Entities.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("complaints");
                });

            modelBuilder.Entity("BackEnd.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HealthCenterId")
                        .HasColumnType("int");

                    b.Property<int>("IndividualId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HealthCenterId");

                    b.HasIndex("IndividualId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.HasIndex("WorkId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("BackEnd.Entities.FamilyRegestrationCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("familyRegestrationCards");
                });

            modelBuilder.Entity("BackEnd.Entities.HealthCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("healthCenters");
                });

            modelBuilder.Entity("BackEnd.Entities.Illness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IllnessTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IllnessTypeId");

                    b.ToTable("illnesses");
                });

            modelBuilder.Entity("BackEnd.Entities.IllnessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("illnessTypes");
                });

            modelBuilder.Entity("BackEnd.Entities.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamilyRegestrationCardId")
                        .HasColumnType("int");

                    b.Property<int>("FatherId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("LastName")
                        .HasColumnType("int");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<int>("OriginalPlaceId")
                        .HasColumnType("int");

                    b.Property<int>("RelationShipId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentialAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamilyRegestrationCardId");

                    b.HasIndex("FatherId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("OriginalPlaceId");

                    b.HasIndex("RelationShipId");

                    b.HasIndex("ResidentialAddressId");

                    b.ToTable("Individual");
                });

            modelBuilder.Entity("BackEnd.Entities.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("nationalities");
                });

            modelBuilder.Entity("BackEnd.Entities.OriginalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("originalPlaces");
                });

            modelBuilder.Entity("BackEnd.Entities.Preview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("IndividialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("IndividialId");

                    b.ToTable("previews");
                });

            modelBuilder.Entity("BackEnd.Entities.Relationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("relationships");
                });

            modelBuilder.Entity("BackEnd.Entities.ResidentialAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("residentialAddresses");
                });

            modelBuilder.Entity("BackEnd.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("BackEnd.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("works");
                });

            modelBuilder.Entity("BackEnd.NewFolder.InitialClassTest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("initialClassTests");
                });

            modelBuilder.Entity("BackEnd.Entities.Employee", b =>
                {
                    b.HasOne("BackEnd.Entities.HealthCenter", "healthCenter")
                        .WithMany()
                        .HasForeignKey("HealthCenterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Individual", "individual")
                        .WithOne()
                        .HasForeignKey("BackEnd.Entities.Employee", "IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Team", "team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Work", "work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("healthCenter");

                    b.Navigation("individual");

                    b.Navigation("team");

                    b.Navigation("work");
                });

            modelBuilder.Entity("BackEnd.Entities.HealthCenter", b =>
                {
                    b.HasOne("BackEnd.Entities.Area", "area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("area");
                });

            modelBuilder.Entity("BackEnd.Entities.Illness", b =>
                {
                    b.HasOne("BackEnd.Entities.IllnessType", "illnessType")
                        .WithMany()
                        .HasForeignKey("IllnessTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("illnessType");
                });

            modelBuilder.Entity("BackEnd.Entities.Individual", b =>
                {
                    b.HasOne("BackEnd.Entities.FamilyRegestrationCard", "familyRegestrationCard")
                        .WithMany()
                        .HasForeignKey("FamilyRegestrationCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Individual", "individual")
                        .WithMany()
                        .HasForeignKey("FatherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Nationality", "nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.OriginalPlace", "originalPlace")
                        .WithMany()
                        .HasForeignKey("OriginalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Relationship", "relatioship")
                        .WithMany()
                        .HasForeignKey("RelationShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.ResidentialAddress", "residentialAddress")
                        .WithMany()
                        .HasForeignKey("ResidentialAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("familyRegestrationCard");

                    b.Navigation("individual");

                    b.Navigation("nationality");

                    b.Navigation("originalPlace");

                    b.Navigation("relatioship");

                    b.Navigation("residentialAddress");
                });

            modelBuilder.Entity("BackEnd.Entities.Preview", b =>
                {
                    b.HasOne("BackEnd.Entities.Employee", "doctore")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Entities.Individual", "individual")
                        .WithMany()
                        .HasForeignKey("IndividialId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("doctore");

                    b.Navigation("individual");
                });

            modelBuilder.Entity("BackEnd.Entities.ResidentialAddress", b =>
                {
                    b.HasOne("BackEnd.Entities.Area", "area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("area");
                });
#pragma warning restore 612, 618
        }
    }
}
