using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birthday", "Email", "FirstName", "LastName", "MiddleName", "PassportNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { -30, "ул. Тверская, д. 27, кв. 5, Самара", new DateOnly(2004, 8, 18), null, "Евгений", "Ефимов", "Павлович", "0123 567890", "79990123456" },
                    { -29, null, new DateOnly(2005, 6, 6), null, "Максим", "Николаев", "Романович", "9012 456789", "79889012345" },
                    { -28, "ул. Кольцова, д. 3, кв. 7, Архангельск", new DateOnly(2015, 1, 18), null, "Владимир", "Медведев", "Евгеньевич", "8901 345678", "79778901234" },
                    { -27, null, new DateOnly(2003, 12, 14), "grigorev@gmail.com", "Роман", "Григорьев", "Максимович", "7890 234567", "79667890123" },
                    { -26, null, new DateOnly(1961, 12, 12), null, "Юрий", "Зайцев", "Артёмович", "6789 123456", "79556789012" },
                    { -25, null, new DateOnly(2001, 1, 22), null, "Виктор", "Марков", "Викторович", "5678 012345", "79445678901" },
                    { -24, null, new DateOnly(1977, 10, 1), "orlov@gmail.com", "Олег", "Орлов", "Олегович", "4567 901234", "79334567890" },
                    { -23, null, new DateOnly(2018, 10, 24), null, "Константин", "Белов", "Константинович", "3456 890123", "79223456789" },
                    { -22, null, new DateOnly(1996, 3, 22), "fedorov@yahoo.com", "Пётр", "Фёдоров", "Петрович", "2345 789012", "79112345678" },
                    { -21, null, new DateOnly(2007, 2, 20), null, "Александр", "Соловьёв", "Григорьевич", "1234 678901", "79990011223" },
                    { -20, null, null, null, null, null, null, null, "79888990011" },
                    { -19, null, null, null, null, null, null, null, "79777889900" },
                    { -18, null, null, null, null, null, null, null, "79666778899" },
                    { -17, null, null, null, null, null, null, null, "79555667788" },
                    { -16, null, null, null, null, null, null, null, "79444556677" },
                    { -15, null, null, null, null, null, null, null, "79333445566" },
                    { -14, null, null, null, null, null, null, null, "79222334455" },
                    { -13, null, null, null, null, null, null, null, "79111223344" },
                    { -12, null, null, null, null, null, null, null, "79876543210" },
                    { -11, null, null, null, null, null, null, null, "79991234567" },
                    { -10, null, null, "morozov@mail.com", "Григорий", "Морозов", "Владимирович", null, null },
                    { -9, null, null, "novikov@gmail.com", "Василий", "Новиков", "Юрьевич", null, null },
                    { -8, null, null, "pavlov@outlook.com", "Сергей", "Павлов", "Николаевич", null, null },
                    { -7, null, null, "smirnov@yandex.ru", "Андрей", "Смирнов", "Михайлович", null, null },
                    { -6, null, null, "popov@gmail.com", "Николай", "Попов", "Васильевич", null, null },
                    { -5, null, null, "kuznetsov@mail.ru", "Артём", "Кузнецов", "Андреевич", null, null },
                    { -4, null, null, "vasilev@outlook.com", "Дмитрий", "Васильев", "Сергеевич", null, null },
                    { -3, null, null, "sidorov@yahoo.com", "Михаил", "Сидоров", "Дмитриевич", null, null },
                    { -2, null, null, "petrov@gmail.com", "Алексей", "Петров", "Алексеевич", null, null },
                    { -1, null, null, "ivanov@mail.com", "Иван", "Иванов", "Иванович", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
