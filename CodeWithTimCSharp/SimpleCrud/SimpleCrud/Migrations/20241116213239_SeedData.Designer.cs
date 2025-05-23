﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleCrud.DataAccess.Entities;

#nullable disable

namespace SimpleCrud.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241116213239_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleCrud.DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Age = 49,
                            DateOfBirth = new DateTime(1974, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Sales",
                            FullName = "MHSN27 MHSN",
                            PhoneNumber = "+1 1774867925"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Age = 44,
                            DateOfBirth = new DateTime(1979, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "Sohel Shaikh",
                            PhoneNumber = "+1 1280221170"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Age = 43,
                            DateOfBirth = new DateTime(1980, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Public Relations (PR)",
                            FullName = "Mark Johnnah",
                            PhoneNumber = "+1 6391420937"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Age = 55,
                            DateOfBirth = new DateTime(1968, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Quality Assurance (QA)",
                            FullName = "JB _",
                            PhoneNumber = "+1 1634119861"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Age = 70,
                            DateOfBirth = new DateTime(1953, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Logistics",
                            FullName = "hugo sanchez",
                            PhoneNumber = "+1 7644917715"
                        },
                        new
                        {
                            EmployeeId = 6,
                            Age = 70,
                            DateOfBirth = new DateTime(1953, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Administration",
                            FullName = "Zabi Rahmani",
                            PhoneNumber = "+1 5082755411"
                        },
                        new
                        {
                            EmployeeId = 7,
                            Age = 60,
                            DateOfBirth = new DateTime(1963, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Training and Development",
                            FullName = "edimar lopes",
                            PhoneNumber = "+1 5745426751"
                        },
                        new
                        {
                            EmployeeId = 8,
                            Age = 43,
                            DateOfBirth = new DateTime(1980, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Research and Development (R&D)",
                            FullName = "Arie melans",
                            PhoneNumber = "+1 5367480161"
                        },
                        new
                        {
                            EmployeeId = 9,
                            Age = 53,
                            DateOfBirth = new DateTime(1970, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "Ziya Çetinkaya",
                            PhoneNumber = "+1 2379992102"
                        },
                        new
                        {
                            EmployeeId = 10,
                            Age = 18,
                            DateOfBirth = new DateTime(2005, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Public Relations (PR)",
                            FullName = "Thiago Paiva Medeiros",
                            PhoneNumber = "+1 2495860935"
                        },
                        new
                        {
                            EmployeeId = 11,
                            Age = 56,
                            DateOfBirth = new DateTime(1967, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Facilities Management",
                            FullName = "Thanh Nguyen",
                            PhoneNumber = "+1 3911316611"
                        },
                        new
                        {
                            EmployeeId = 12,
                            Age = 39,
                            DateOfBirth = new DateTime(1984, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Sales",
                            FullName = "Rahul Salokhe",
                            PhoneNumber = "+1 5182461859"
                        },
                        new
                        {
                            EmployeeId = 13,
                            Age = 23,
                            DateOfBirth = new DateTime(2000, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Operations",
                            FullName = "Jing Tarng Loke",
                            PhoneNumber = "+1 2635917946"
                        },
                        new
                        {
                            EmployeeId = 14,
                            Age = 36,
                            DateOfBirth = new DateTime(1987, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Human Resources (HR)",
                            FullName = "met it",
                            PhoneNumber = "+1 5049298944"
                        },
                        new
                        {
                            EmployeeId = 15,
                            Age = 50,
                            DateOfBirth = new DateTime(1973, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Research and Development (R&D)",
                            FullName = "Md.Ariful Islam",
                            PhoneNumber = "+1 9252292089"
                        },
                        new
                        {
                            EmployeeId = 16,
                            Age = 47,
                            DateOfBirth = new DateTime(1976, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Legal",
                            FullName = "Mo Canada",
                            PhoneNumber = "+1 1824118974"
                        },
                        new
                        {
                            EmployeeId = 17,
                            Age = 26,
                            DateOfBirth = new DateTime(1997, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Administration",
                            FullName = "Altanzurkh T",
                            PhoneNumber = "+1 6395646874"
                        },
                        new
                        {
                            EmployeeId = 18,
                            Age = 72,
                            DateOfBirth = new DateTime(1951, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Public Relations (PR)",
                            FullName = "Mustafa YILDIZ",
                            PhoneNumber = "+1 1375269492"
                        },
                        new
                        {
                            EmployeeId = 19,
                            Age = 64,
                            DateOfBirth = new DateTime(1959, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Quality Assurance (QA)",
                            FullName = "Arief Fauzi",
                            PhoneNumber = "+1 3458476129"
                        },
                        new
                        {
                            EmployeeId = 20,
                            Age = 72,
                            DateOfBirth = new DateTime(1951, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Engineering",
                            FullName = "salvador castillo",
                            PhoneNumber = "+1 4486306495"
                        },
                        new
                        {
                            EmployeeId = 21,
                            Age = 62,
                            DateOfBirth = new DateTime(1961, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Training and Development",
                            FullName = "Luis TC",
                            PhoneNumber = "+1 1280221170"
                        },
                        new
                        {
                            EmployeeId = 22,
                            Age = 32,
                            DateOfBirth = new DateTime(1991, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Finance",
                            FullName = "Adeel Baig",
                            PhoneNumber = "+1 6391420937"
                        },
                        new
                        {
                            EmployeeId = 23,
                            Age = 52,
                            DateOfBirth = new DateTime(1971, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Information Technology (IT)",
                            FullName = "Novrita Inkac",
                            PhoneNumber = "+1 1634119861"
                        },
                        new
                        {
                            EmployeeId = 24,
                            Age = 57,
                            DateOfBirth = new DateTime(1966, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Data Analytics",
                            FullName = "Felipe Rodríguez",
                            PhoneNumber = "+1 7644917715"
                        },
                        new
                        {
                            EmployeeId = 25,
                            Age = 30,
                            DateOfBirth = new DateTime(1993, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Legal",
                            FullName = "Fabian Cebreros",
                            PhoneNumber = "+1 5082755411"
                        },
                        new
                        {
                            EmployeeId = 26,
                            Age = 53,
                            DateOfBirth = new DateTime(1970, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Customer Support",
                            FullName = "Alan Michas",
                            PhoneNumber = "+1 5745426751"
                        },
                        new
                        {
                            EmployeeId = 27,
                            Age = 66,
                            DateOfBirth = new DateTime(1957, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Administration",
                            FullName = "Lucky D.Bog",
                            PhoneNumber = "+1 5367480161"
                        },
                        new
                        {
                            EmployeeId = 28,
                            Age = 55,
                            DateOfBirth = new DateTime(1968, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Research and Development (R&D)",
                            FullName = "Anunu",
                            PhoneNumber = "+1 2379992102"
                        },
                        new
                        {
                            EmployeeId = 29,
                            Age = 26,
                            DateOfBirth = new DateTime(1997, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "KRAK 08",
                            PhoneNumber = "+1 2495860935"
                        },
                        new
                        {
                            EmployeeId = 30,
                            Age = 47,
                            DateOfBirth = new DateTime(1976, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Customer Support",
                            FullName = "Boonsit Chanpoempoonpol",
                            PhoneNumber = "+1 3911316611"
                        },
                        new
                        {
                            EmployeeId = 31,
                            Age = 44,
                            DateOfBirth = new DateTime(1979, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Business Development",
                            FullName = "Danilo Romao",
                            PhoneNumber = "+1 5182461859"
                        },
                        new
                        {
                            EmployeeId = 32,
                            Age = 24,
                            DateOfBirth = new DateTime(1999, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Logistics",
                            FullName = "User 4571",
                            PhoneNumber = "+1 2635917946"
                        },
                        new
                        {
                            EmployeeId = 33,
                            Age = 47,
                            DateOfBirth = new DateTime(1976, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Information Technology (IT)",
                            FullName = "Yuri Svyrydov",
                            PhoneNumber = "+1 5049298944"
                        },
                        new
                        {
                            EmployeeId = 34,
                            Age = 37,
                            DateOfBirth = new DateTime(1986, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Procurement",
                            FullName = "Omar Abdelrahim",
                            PhoneNumber = "+1 9252292089"
                        },
                        new
                        {
                            EmployeeId = 35,
                            Age = 30,
                            DateOfBirth = new DateTime(1993, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Quality Assurance (QA)",
                            FullName = "ADIAN Jan",
                            PhoneNumber = "+1 1824118974"
                        },
                        new
                        {
                            EmployeeId = 36,
                            Age = 20,
                            DateOfBirth = new DateTime(2003, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Finance",
                            FullName = "Thiago Valim",
                            PhoneNumber = "+1 6395646874"
                        },
                        new
                        {
                            EmployeeId = 37,
                            Age = 43,
                            DateOfBirth = new DateTime(1980, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Facilities Management",
                            FullName = "ศุภชัย สมพานิช",
                            PhoneNumber = "+1 1375269492"
                        },
                        new
                        {
                            EmployeeId = 38,
                            Age = 48,
                            DateOfBirth = new DateTime(1975, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Customer Support",
                            FullName = "ArTWorK211",
                            PhoneNumber = "+1 3458476129"
                        },
                        new
                        {
                            EmployeeId = 39,
                            Age = 69,
                            DateOfBirth = new DateTime(1954, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Information Technology (IT)",
                            FullName = "Johny Angsana",
                            PhoneNumber = "+1 4486306495"
                        },
                        new
                        {
                            EmployeeId = 40,
                            Age = 66,
                            DateOfBirth = new DateTime(1957, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Administration",
                            FullName = "kommineni narendra",
                            PhoneNumber = "+1 1774867925"
                        },
                        new
                        {
                            EmployeeId = 41,
                            Age = 52,
                            DateOfBirth = new DateTime(1971, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Procurement",
                            FullName = "Felipe Ramos",
                            PhoneNumber = "+1 1280221170"
                        },
                        new
                        {
                            EmployeeId = 42,
                            Age = 25,
                            DateOfBirth = new DateTime(1998, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Operations",
                            FullName = "Maroine Chérif",
                            PhoneNumber = "+1 6391420937"
                        },
                        new
                        {
                            EmployeeId = 43,
                            Age = 37,
                            DateOfBirth = new DateTime(1986, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Engineering",
                            FullName = "Sana Ullah",
                            PhoneNumber = "+1 1634119861"
                        },
                        new
                        {
                            EmployeeId = 44,
                            Age = 50,
                            DateOfBirth = new DateTime(1973, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Public Relations (PR)",
                            FullName = "michel akebo",
                            PhoneNumber = "+1 7644917715"
                        },
                        new
                        {
                            EmployeeId = 45,
                            Age = 42,
                            DateOfBirth = new DateTime(1981, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Logistics",
                            FullName = "عمر العمودي Omar Al-Amoudi",
                            PhoneNumber = "+1 5082755411"
                        },
                        new
                        {
                            EmployeeId = 46,
                            Age = 20,
                            DateOfBirth = new DateTime(2003, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Business Development",
                            FullName = "Louay Abdel Maeen",
                            PhoneNumber = "+1 5745426751"
                        },
                        new
                        {
                            EmployeeId = 47,
                            Age = 56,
                            DateOfBirth = new DateTime(1967, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Marketing",
                            FullName = "Black-Gold Sarnaut",
                            PhoneNumber = "+1 5367480161"
                        },
                        new
                        {
                            EmployeeId = 48,
                            Age = 55,
                            DateOfBirth = new DateTime(1968, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Finance",
                            FullName = "gueye abdoulaye",
                            PhoneNumber = "+1 2379992102"
                        },
                        new
                        {
                            EmployeeId = 49,
                            Age = 34,
                            DateOfBirth = new DateTime(1989, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Engineering",
                            FullName = "Cristian Ferreira",
                            PhoneNumber = "+1 2495860935"
                        },
                        new
                        {
                            EmployeeId = 50,
                            Age = 51,
                            DateOfBirth = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Finance",
                            FullName = "Amir Osama",
                            PhoneNumber = "+1 3911316611"
                        },
                        new
                        {
                            EmployeeId = 51,
                            Age = 58,
                            DateOfBirth = new DateTime(1965, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Human Resources (HR)",
                            FullName = "Mihai Moisei",
                            PhoneNumber = "+1 5182461859"
                        },
                        new
                        {
                            EmployeeId = 52,
                            Age = 18,
                            DateOfBirth = new DateTime(2005, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Procurement",
                            FullName = "AKHOM ALY",
                            PhoneNumber = "+1 2635917946"
                        },
                        new
                        {
                            EmployeeId = 53,
                            Age = 52,
                            DateOfBirth = new DateTime(1971, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Customer Support",
                            FullName = "Banpote Jaruboon",
                            PhoneNumber = "+1 5049298944"
                        },
                        new
                        {
                            EmployeeId = 54,
                            Age = 61,
                            DateOfBirth = new DateTime(1962, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Sales",
                            FullName = "Abdul Razak Abdulai",
                            PhoneNumber = "+1 9252292089"
                        },
                        new
                        {
                            EmployeeId = 55,
                            Age = 22,
                            DateOfBirth = new DateTime(2001, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "ELy moussa",
                            PhoneNumber = "+1 1824118974"
                        },
                        new
                        {
                            EmployeeId = 56,
                            Age = 40,
                            DateOfBirth = new DateTime(1983, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Facilities Management",
                            FullName = "peter tharwat",
                            PhoneNumber = "+1 6395646874"
                        },
                        new
                        {
                            EmployeeId = 57,
                            Age = 38,
                            DateOfBirth = new DateTime(1985, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Finance",
                            FullName = "william programer (CLASH OF CLAN)",
                            PhoneNumber = "+1 1375269492"
                        },
                        new
                        {
                            EmployeeId = 58,
                            Age = 54,
                            DateOfBirth = new DateTime(1969, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Sales",
                            FullName = "Luis Correa",
                            PhoneNumber = "+1 3458476129"
                        },
                        new
                        {
                            EmployeeId = 59,
                            Age = 58,
                            DateOfBirth = new DateTime(1965, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "Michael Chizoba",
                            PhoneNumber = "+1 4486306495"
                        },
                        new
                        {
                            EmployeeId = 60,
                            Age = 18,
                            DateOfBirth = new DateTime(2005, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Quality Assurance (QA)",
                            FullName = "Abdul-Rouf Ammar",
                            PhoneNumber = "+1 1280221170"
                        },
                        new
                        {
                            EmployeeId = 61,
                            Age = 23,
                            DateOfBirth = new DateTime(2000, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Marketing",
                            FullName = "Norbert Saint Georges",
                            PhoneNumber = "+1 6391420937"
                        },
                        new
                        {
                            EmployeeId = 62,
                            Age = 19,
                            DateOfBirth = new DateTime(2004, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Research and Development (R&D)",
                            FullName = "trieuvnh",
                            PhoneNumber = "+1 1634119861"
                        },
                        new
                        {
                            EmployeeId = 63,
                            Age = 60,
                            DateOfBirth = new DateTime(1963, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Procurement",
                            FullName = "Amr Moh",
                            PhoneNumber = "+1 7644917715"
                        },
                        new
                        {
                            EmployeeId = 64,
                            Age = 20,
                            DateOfBirth = new DateTime(2003, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Information Technology (IT)",
                            FullName = "Ton",
                            PhoneNumber = "+1 5082755411"
                        },
                        new
                        {
                            EmployeeId = 65,
                            Age = 66,
                            DateOfBirth = new DateTime(1957, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Quality Assurance (QA)",
                            FullName = "Prathamesh Karande",
                            PhoneNumber = "+1 5745426751"
                        },
                        new
                        {
                            EmployeeId = 66,
                            Age = 73,
                            DateOfBirth = new DateTime(1950, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Human Resources (HR)",
                            FullName = "MarianoT3",
                            PhoneNumber = "+1 5367480161"
                        },
                        new
                        {
                            EmployeeId = 67,
                            Age = 34,
                            DateOfBirth = new DateTime(1989, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Human Resources (HR)",
                            FullName = "Rekzon Aborde",
                            PhoneNumber = "+1 2379992102"
                        },
                        new
                        {
                            EmployeeId = 68,
                            Age = 43,
                            DateOfBirth = new DateTime(1980, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Information Technology (IT)",
                            FullName = "prottoy roy",
                            PhoneNumber = "+1 2495860935"
                        },
                        new
                        {
                            EmployeeId = 69,
                            Age = 22,
                            DateOfBirth = new DateTime(2001, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Product Management",
                            FullName = "sahli SAHBI",
                            PhoneNumber = "+1 3911316611"
                        },
                        new
                        {
                            EmployeeId = 70,
                            Age = 46,
                            DateOfBirth = new DateTime(1977, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Administration",
                            FullName = "Onur Hos",
                            PhoneNumber = "+1 5182461859"
                        },
                        new
                        {
                            EmployeeId = 71,
                            Age = 45,
                            DateOfBirth = new DateTime(1978, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Data Analytics",
                            FullName = "Armando Villagomez",
                            PhoneNumber = "+1 2635917946"
                        },
                        new
                        {
                            EmployeeId = 72,
                            Age = 35,
                            DateOfBirth = new DateTime(1988, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Facilities Management",
                            FullName = "Jesus Alberto Roque Ortiz",
                            PhoneNumber = "+1 5049298944"
                        },
                        new
                        {
                            EmployeeId = 73,
                            Age = 59,
                            DateOfBirth = new DateTime(1964, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Facilities Management",
                            FullName = "Md Shahin Aktar",
                            PhoneNumber = "+1 9252292089"
                        },
                        new
                        {
                            EmployeeId = 74,
                            Age = 65,
                            DateOfBirth = new DateTime(1958, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Customer Support",
                            FullName = "Антон Метелёв",
                            PhoneNumber = "+1 1824118974"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
