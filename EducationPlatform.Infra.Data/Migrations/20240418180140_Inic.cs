using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationPlatform.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Signatures_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "Signatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSignatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SignatureId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSignatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSignatures_Signatures_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "Signatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSignatures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSignatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdExternalPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserSignature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSignatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentSignatures_UserSignatures_IdUserSignature",
                        column: x => x.IdUserSignature,
                        principalTable: "UserSignatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessonCompleted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdLesson = table.Column<int>(type: "int", nullable: false),
                    FinishedLesson = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonCompleted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLessonCompleted_Lessons_IdLesson",
                        column: x => x.IdLesson,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLessonCompleted_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Signatures",
                columns: new[] { "Id", "Duration", "IsActive", "Name" },
                values: new object[] { 1, 365, true, "Padrão" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessLevel", "Birthday", "CPF", "Email", "FullName", "IsActive", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "06445661327", "abi@mail.com", "abi", true, "123456789", "86952258855" },
                    { 2, 1, new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678910", "joao@mail.com", "nay", true, "123456789", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Cover", "CreationDate", "Description", "Name", "SignatureId" },
                values: new object[] { 1, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.treinaweb.com.br%2Fblog%2Fcomo-instalar-o-csharp-e-nosso-primeiro-exemplo&psig=AOvVaw1j2JR7fNFScafseX_uX4qA&ust=1713292306049000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCPDhk67txIUDFQAAAAAdAAAAABAE", new DateTime(2024, 4, 18, 15, 1, 39, 601, DateTimeKind.Local).AddTicks(3973), "Iniciando pelo básico do C#", "Introdução o C#", 1 });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "CreationDate", "Description", "IdCourse", "Name" },
                values: new object[] { 1, new DateTime(2024, 4, 18, 15, 1, 39, 601, DateTimeKind.Local).AddTicks(1492), "Description", 1, "Instalção das ferramentas" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BlockId", "CreationDate", "Description", "Duration", "LinkVideo", "Name" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 18, 15, 1, 39, 601, DateTimeKind.Local).AddTicks(5662), "Descrição", 600, "https://www.youtube.com/watch?v=PZ7HiQdT0Dw", "Visual Studio Code" });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_IdCourse",
                table: "Blocks",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SignatureId",
                table: "Courses",
                column: "SignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_BlockId",
                table: "Lessons",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSignatures_IdUserSignature",
                table: "PaymentSignatures",
                column: "IdUserSignature");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonCompleted_IdLesson",
                table: "UserLessonCompleted",
                column: "IdLesson");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonCompleted_IdUser",
                table: "UserLessonCompleted",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserSignatures_SignatureId",
                table: "UserSignatures",
                column: "SignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSignatures_UserId",
                table: "UserSignatures",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSignatures");

            migrationBuilder.DropTable(
                name: "UserLessonCompleted");

            migrationBuilder.DropTable(
                name: "UserSignatures");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Signatures");
        }
    }
}
