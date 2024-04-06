using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class AddIsActiveColumnForSoftDeletingQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9469eb50-bd12-4fd3-bc59-ce05058d0ac9"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e0e116da-8efd-4dc6-937f-36e68637063e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("1b93b15b-b661-4f98-8939-6c9cb0b1e1e5"), new DateTime(2024, 4, 6, 19, 47, 48, 62, DateTimeKind.Local).AddTicks(4079), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 6, 19, 47, 48, 62, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("dcc2b34f-3bf6-41eb-97ac-5f6a9c68e277"), new DateTime(2024, 4, 6, 19, 47, 48, 62, DateTimeKind.Local).AddTicks(4134), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 6, 19, 47, 48, 62, DateTimeKind.Local).AddTicks(4135) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("1b93b15b-b661-4f98-8939-6c9cb0b1e1e5"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("dcc2b34f-3bf6-41eb-97ac-5f6a9c68e277"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("9469eb50-bd12-4fd3-bc59-ce05058d0ac9"), new DateTime(2024, 4, 3, 22, 22, 47, 574, DateTimeKind.Local).AddTicks(7615), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 4, 3, 22, 22, 47, 574, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[] { new Guid("e0e116da-8efd-4dc6-937f-36e68637063e"), new DateTime(2024, 4, 3, 22, 22, 47, 574, DateTimeKind.Local).AddTicks(7685), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 4, 3, 22, 22, 47, 574, DateTimeKind.Local).AddTicks(7686) });
        }
    }
}
