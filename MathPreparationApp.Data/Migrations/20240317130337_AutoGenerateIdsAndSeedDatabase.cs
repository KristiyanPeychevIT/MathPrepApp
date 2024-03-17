using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class AutoGenerateIdsAndSeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Начален преговор от 6. клас" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Цели изрази" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Умножение и деление на рационални цисла", 1 });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Едночлени", 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("cd0491bf-b568-4a87-9635-9123a1b73f4d"), new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2644), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2676) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("eee31a27-2c80-48b2-b693-9a65596670b7"), new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2733), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2735) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("cd0491bf-b568-4a87-9635-9123a1b73f4d"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("eee31a27-2c80-48b2-b693-9a65596670b7"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
