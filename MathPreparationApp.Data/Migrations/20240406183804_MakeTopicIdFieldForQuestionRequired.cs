using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class MakeTopicIdFieldForQuestionRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("5561f712-037c-40a1-8e5f-d2acc0ac7042"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("a5d76e20-40cc-4dc9-8b40-a98f7aab38aa"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("63fa347b-5afc-414d-9144-17beb8909730"), new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9339), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9378) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("7641983c-24bd-4764-bb5a-2c7bbb62ed45"), new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9401), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9403) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("63fa347b-5afc-414d-9144-17beb8909730"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("7641983c-24bd-4764-bb5a-2c7bbb62ed45"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("5561f712-037c-40a1-8e5f-d2acc0ac7042"), new DateTime(2024, 4, 6, 21, 36, 55, 683, DateTimeKind.Local).AddTicks(1676), "5x²y³z", null, false, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 6, 21, 36, 55, 683, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("a5d76e20-40cc-4dc9-8b40-a98f7aab38aa"), new DateTime(2024, 4, 6, 21, 36, 55, 683, DateTimeKind.Local).AddTicks(1603), "-32", null, false, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 6, 21, 36, 55, 683, DateTimeKind.Local).AddTicks(1650) });
        }
    }
}
