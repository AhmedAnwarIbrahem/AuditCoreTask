﻿// <auto-generated />
using System;
using HrTasks.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HrTasks.Model.Migrations
{
    [DbContext(typeof(HrTasksContext))]
    [Migration("20191020102925_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HrTasks.Model.Entites.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentAr");

                    b.Property<string>("DepartmentEn");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HrTasks.Model.Entites.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("EmployeeNameAr");

                    b.Property<string>("EmployeeNameEn");

                    b.Property<bool>("IsManger");

                    b.Property<DateTime>("JoinDate");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HrTasks.Model.Entites.EmployeeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("HrTasks.Model.Entites.Employee", b =>
                {
                    b.HasOne("HrTasks.Model.Entites.Department", "Departments")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HrTasks.Model.Entites.EmployeeTask", b =>
                {
                    b.HasOne("HrTasks.Model.Entites.Employee", "Employees")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
