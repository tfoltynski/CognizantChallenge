using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantChallenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    SolvedTasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => new { x.SolvedTasksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserTasks_Tasks_SolvedTasksId",
                        column: x => x.SolvedTasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Input", "Output", "TaskName" },
                values: new object[,]
                {
                    { new Guid("614f97de-6131-4a30-84c0-caf32aec4dad"), "Write a program that prints at least 10 members of the Fibonacci sequence, the starting input will be in following format: 2,3", "2,3", "5 8 13 21 34 55 89 144 233 377", "Fibonacci series" },
                    { new Guid("1365247a-c078-453f-b378-83a1750e27c3"), "You have a collection of integers, 1 to 30. I want you to cycle through this collection. For each number found that is evenly divisible by 3, output the word 'Fizz'. For each number that is evenly divisible by 5, output the word 'Buzz'. For each number that is evenly divisible by both 3 AND 5, output the word 'FizzBuzz'.", "", "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz", "FizzBuzz" },
                    { new Guid("62b2866f-fec4-46b5-85cb-f5d4832a4477"), "Write a program that prints at least 25 first prime numbers. Prime number is a number that is greater than 1 and divided by 1 or itself. In other words, prime numbers can't be divided by other numbers than itself or 1.", "", "2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 83 89 97", "Prime numbers" },
                    { new Guid("b644f15c-b2c6-44cd-9304-2ca09697bc66"), "Write a C# Sharp program that takes four numbers as input to calculate and print the average. The input numbers will be in following format: 10,15,20,30", "10,15,20,30", "18", "Average numbers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UsersId",
                table: "UserTasks",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
