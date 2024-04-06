using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class MakeTopicIdExplicitlyRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("dd5444fa-15d7-424b-9d2a-a6dfde179058"), new DateTime(2024, 4, 6, 21, 52, 24, 194, DateTimeKind.Local).AddTicks(6183), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 6, 21, 52, 24, 194, DateTimeKind.Local).AddTicks(6184) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("ffa4a057-d5a6-4cec-938d-df833e3612a2"), new DateTime(2024, 4, 6, 21, 52, 24, 194, DateTimeKind.Local).AddTicks(6130), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 6, 21, 52, 24, 194, DateTimeKind.Local).AddTicks(6167) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("dd5444fa-15d7-424b-9d2a-a6dfde179058"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ffa4a057-d5a6-4cec-938d-df833e3612a2"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("63fa347b-5afc-414d-9144-17beb8909730"), new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9339), "-32", null, false, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9378) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("7641983c-24bd-4764-bb5a-2c7bbb62ed45"), new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9401), "5x²y³z", null, false, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 6, 21, 38, 4, 115, DateTimeKind.Local).AddTicks(9403) });
        }
    }
}
