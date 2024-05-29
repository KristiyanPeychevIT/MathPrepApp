using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathPreparationApp.Data.Migrations
{
    public partial class SeededUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("220e7d67-4aa4-43ac-b091-a8f33099a77c"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("fcd27e1f-10ad-4146-b026-f15f82c11d5c"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "306210d5-0507-429a-8c3a-73913d482576", "AQAAAAEAACcQAAAAEGkdsUBvF39LKQWr+RwvVL3RPuWcRcK3z1jDvWJQ8nyg8tUPiYoYUaYb9TlpUXXF7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa76088c-c053-4a4b-a0c5-bb931c606c78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9b8454a-f1fe-48a9-ba95-0f197198247a", "AQAAAAEAACcQAAAAECIwbFZU9+KJTIYGeo/ErXSW/j1q10YHVb/Cke3Qnmg+0sz7x3BBy6Aun5SfMcdJvQ==" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("6a54c26f-a2ef-43ab-bc9a-56096898dc79"), new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5718), "-32", null, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5821) },
                    { new Guid("c6e461e6-b8a6-40c4-9f9c-e47f18c0264a"), new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5846), "5x²y³z", null, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 5, 29, 23, 18, 49, 223, DateTimeKind.Local).AddTicks(5847) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b5e45b-db73-40cf-9d83-0625c5026314", "AQAAAAEAACcQAAAAEMGNITkMJYb3LmmXBg9qv49k98feiqIGyUM3qxbz1AQmvCH3Lri4X1dWjHDIxwx54w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa76088c-c053-4a4b-a0c5-bb931c606c78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39afa8fe-2976-4c44-af7b-eb4e76593ef2", "AQAAAAEAACcQAAAAEA/Pmp0A0NBVC2poyPFFL42eqvzhtTwMxquJDOdquHmAVPvrF6vfe0CvzPYzwXU19g==" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AddedOn", "CorrectOption", "ImageBytes", "IsActive", "Name", "Option1", "Option2", "Option3", "Option4", "Points", "Solution", "SubjectId", "TopicId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("220e7d67-4aa4-43ac-b091-a8f33099a77c"), new DateTime(2024, 5, 29, 23, 8, 43, 893, DateTimeKind.Local).AddTicks(3865), "-32", null, false, "Пресметнете стойността на израза: 4.(-8)", "32", "-32", "-12", "12", 2, "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.", 1, 2, new DateTime(2024, 5, 29, 23, 8, 43, 893, DateTimeKind.Local).AddTicks(3897) },
                    { new Guid("fcd27e1f-10ad-4146-b026-f15f82c11d5c"), new DateTime(2024, 5, 29, 23, 8, 43, 893, DateTimeKind.Local).AddTicks(3923), "5x²y³z", null, false, "Запишете в нормален вид едночлена: 5xxyy²z", "5xyy", "5x³yz", "5xy³z", "5x²y³z", 2, "x по x = x², y по у² = y³", 2, 2, new DateTime(2024, 5, 29, 23, 8, 43, 893, DateTimeKind.Local).AddTicks(3924) }
                });
        }
    }
}
