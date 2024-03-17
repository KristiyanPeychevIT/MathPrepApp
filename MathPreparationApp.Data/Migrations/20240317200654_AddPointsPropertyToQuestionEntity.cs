using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class AddPointsPropertyToQuestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("cd0491bf-b568-4a87-9635-9123a1b73f4d"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("eee31a27-2c80-48b2-b693-9a65596670b7"));

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("970a3a87-afda-435c-8c08-0239d80e0a1f"), new DateTime(2024, 3, 17, 22, 6, 54, 607, DateTimeKind.Local).AddTicks(1468), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 3, 17, 22, 6, 54, 607, DateTimeKind.Local).AddTicks(1469) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("a3bc928f-195e-4c06-a617-592eded76b88"), new DateTime(2024, 3, 17, 22, 6, 54, 607, DateTimeKind.Local).AddTicks(1415), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 3, 17, 22, 6, 54, 607, DateTimeKind.Local).AddTicks(1453) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("970a3a87-afda-435c-8c08-0239d80e0a1f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("a3bc928f-195e-4c06-a617-592eded76b88"));

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("cd0491bf-b568-4a87-9635-9123a1b73f4d"), new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2644), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2676) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("eee31a27-2c80-48b2-b693-9a65596670b7"), new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2733), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 3, 17, 15, 3, 37, 94, DateTimeKind.Local).AddTicks(2735) });
        }
    }
}
