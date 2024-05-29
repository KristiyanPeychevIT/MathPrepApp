using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class FixedNormalizedUserNameForAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("6a54c26f-a2ef-43ab-bc9a-56096898dc79"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("c6e461e6-b8a6-40c4-9f9c-e47f18c0264a"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "9e332e3e-767e-46d8-b452-bf0cfe4563b8", "ADMIN@MATHPREPAPP.BG", "AQAAAAEAACcQAAAAEE46aFrW/LelRU/A4AZKCFWyvspoE1XEzP/73sq8FW7qqHa5FqOwznCZ3A4T0R3eXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa76088c-c053-4a4b-a0c5-bb931c606c78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03930ea1-6f04-4006-9b8f-ec82d02eddc6", "AQAAAAEAACcQAAAAEA+H+n1hKvcxwdIGV5xQqGfOTJS+f/hcri8GZaB7efw/cgYjHaP2/5JVfpqLIb3Mxg==" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("95626cea-52b5-4e68-a8fb-9e2a53eba724"), new DateTime(2024, 5, 29, 23, 21, 19, 958, DateTimeKind.Local).AddTicks(5847), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 5, 29, 23, 21, 19, 958, DateTimeKind.Local).AddTicks(5849) },
                    { new Guid("e3ceef07-f716-411c-b914-95d8f0592605"), new DateTime(2024, 5, 29, 23, 21, 19, 958, DateTimeKind.Local).AddTicks(5782), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 5, 29, 23, 21, 19, 958, DateTimeKind.Local).AddTicks(5814) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("95626cea-52b5-4e68-a8fb-9e2a53eba724"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e3ceef07-f716-411c-b914-95d8f0592605"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "306210d5-0507-429a-8c3a-73913d482576", "admin@mathprepapp.bg", "AQAAAAEAACcQAAAAEGkdsUBvF39LKQWr+RwvVL3RPuWcRcK3z1jDvWJQ8nyg8tUPiYoYUaYb9TlpUXXF7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa76088c-c053-4a4b-a0c5-bb931c606c78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9b8454a-f1fe-48a9-ba95-0f197198247a", "AQAAAAEAACcQAAAAECIwbFZU9+KJTIYGeo/ErXSW/j1q10YHVb/Cke3Qnmg+0sz7x3BBy6Aun5SfMcdJvQ==" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("6a54c26f-a2ef-43ab-bc9a-56096898dc79"), new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5718), "-32", null, false, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5821) },
                    { new Guid("c6e461e6-b8a6-40c4-9f9c-e47f18c0264a"), new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5846), "5x²y³z", null, false, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5847) }
                });
        }
    }
}
