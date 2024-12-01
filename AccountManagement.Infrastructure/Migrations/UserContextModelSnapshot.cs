﻿// <auto-generated />
using System;
using AccountManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountManagement.Infrastructure.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "ivanov@mail.com",
                            FirstName = "Иван",
                            LastName = "Иванов",
                            MiddleName = "Иванович"
                        },
                        new
                        {
                            Id = -2,
                            Email = "petrov@gmail.com",
                            FirstName = "Алексей",
                            LastName = "Петров",
                            MiddleName = "Алексеевич"
                        },
                        new
                        {
                            Id = -3,
                            Email = "sidorov@yahoo.com",
                            FirstName = "Михаил",
                            LastName = "Сидоров",
                            MiddleName = "Дмитриевич"
                        },
                        new
                        {
                            Id = -4,
                            Email = "vasilev@outlook.com",
                            FirstName = "Дмитрий",
                            LastName = "Васильев",
                            MiddleName = "Сергеевич"
                        },
                        new
                        {
                            Id = -5,
                            Email = "kuznetsov@mail.ru",
                            FirstName = "Артём",
                            LastName = "Кузнецов",
                            MiddleName = "Андреевич"
                        },
                        new
                        {
                            Id = -6,
                            Email = "popov@gmail.com",
                            FirstName = "Николай",
                            LastName = "Попов",
                            MiddleName = "Васильевич"
                        },
                        new
                        {
                            Id = -7,
                            Email = "smirnov@yandex.ru",
                            FirstName = "Андрей",
                            LastName = "Смирнов",
                            MiddleName = "Михайлович"
                        },
                        new
                        {
                            Id = -8,
                            Email = "pavlov@outlook.com",
                            FirstName = "Сергей",
                            LastName = "Павлов",
                            MiddleName = "Николаевич"
                        },
                        new
                        {
                            Id = -9,
                            Email = "novikov@gmail.com",
                            FirstName = "Василий",
                            LastName = "Новиков",
                            MiddleName = "Юрьевич"
                        },
                        new
                        {
                            Id = -10,
                            Email = "morozov@mail.com",
                            FirstName = "Григорий",
                            LastName = "Морозов",
                            MiddleName = "Владимирович"
                        },
                        new
                        {
                            Id = -11,
                            PhoneNumber = "79991234567"
                        },
                        new
                        {
                            Id = -12,
                            PhoneNumber = "79876543210"
                        },
                        new
                        {
                            Id = -13,
                            PhoneNumber = "79111223344"
                        },
                        new
                        {
                            Id = -14,
                            PhoneNumber = "79222334455"
                        },
                        new
                        {
                            Id = -15,
                            PhoneNumber = "79333445566"
                        },
                        new
                        {
                            Id = -16,
                            PhoneNumber = "79444556677"
                        },
                        new
                        {
                            Id = -17,
                            PhoneNumber = "79555667788"
                        },
                        new
                        {
                            Id = -18,
                            PhoneNumber = "79666778899"
                        },
                        new
                        {
                            Id = -19,
                            PhoneNumber = "79777889900"
                        },
                        new
                        {
                            Id = -20,
                            PhoneNumber = "79888990011"
                        },
                        new
                        {
                            Id = -21,
                            Birthday = new DateOnly(2007, 2, 20),
                            FirstName = "Александр",
                            LastName = "Соловьёв",
                            MiddleName = "Григорьевич",
                            PassportNumber = "1234 678901",
                            PhoneNumber = "79990011223"
                        },
                        new
                        {
                            Id = -22,
                            Birthday = new DateOnly(1996, 3, 22),
                            Email = "fedorov@yahoo.com",
                            FirstName = "Пётр",
                            LastName = "Фёдоров",
                            MiddleName = "Петрович",
                            PassportNumber = "2345 789012",
                            PhoneNumber = "79112345678"
                        },
                        new
                        {
                            Id = -23,
                            Birthday = new DateOnly(2018, 10, 24),
                            FirstName = "Константин",
                            LastName = "Белов",
                            MiddleName = "Константинович",
                            PassportNumber = "3456 890123",
                            PhoneNumber = "79223456789"
                        },
                        new
                        {
                            Id = -24,
                            Birthday = new DateOnly(1977, 10, 1),
                            Email = "orlov@gmail.com",
                            FirstName = "Олег",
                            LastName = "Орлов",
                            MiddleName = "Олегович",
                            PassportNumber = "4567 901234",
                            PhoneNumber = "79334567890"
                        },
                        new
                        {
                            Id = -25,
                            Birthday = new DateOnly(2001, 1, 22),
                            FirstName = "Виктор",
                            LastName = "Марков",
                            MiddleName = "Викторович",
                            PassportNumber = "5678 012345",
                            PhoneNumber = "79445678901"
                        },
                        new
                        {
                            Id = -26,
                            Birthday = new DateOnly(1961, 12, 12),
                            FirstName = "Юрий",
                            LastName = "Зайцев",
                            MiddleName = "Артёмович",
                            PassportNumber = "6789 123456",
                            PhoneNumber = "79556789012"
                        },
                        new
                        {
                            Id = -27,
                            Birthday = new DateOnly(2003, 12, 14),
                            Email = "grigorev@gmail.com",
                            FirstName = "Роман",
                            LastName = "Григорьев",
                            MiddleName = "Максимович",
                            PassportNumber = "7890 234567",
                            PhoneNumber = "79667890123"
                        },
                        new
                        {
                            Id = -28,
                            Address = "ул. Кольцова, д. 3, кв. 7, Архангельск",
                            Birthday = new DateOnly(2015, 1, 18),
                            FirstName = "Владимир",
                            LastName = "Медведев",
                            MiddleName = "Евгеньевич",
                            PassportNumber = "8901 345678",
                            PhoneNumber = "79778901234"
                        },
                        new
                        {
                            Id = -29,
                            Birthday = new DateOnly(2005, 6, 6),
                            FirstName = "Максим",
                            LastName = "Николаев",
                            MiddleName = "Романович",
                            PassportNumber = "9012 456789",
                            PhoneNumber = "79889012345"
                        },
                        new
                        {
                            Id = -30,
                            Address = "ул. Тверская, д. 27, кв. 5, Самара",
                            Birthday = new DateOnly(2004, 8, 18),
                            FirstName = "Евгений",
                            LastName = "Ефимов",
                            MiddleName = "Павлович",
                            PassportNumber = "0123 567890",
                            PhoneNumber = "79990123456"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
