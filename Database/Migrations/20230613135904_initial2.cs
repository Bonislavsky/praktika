using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace praktika.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Users",
                newName: "AreaName");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Голосіївський" },
                    { 2, "Дарницький" },
                    { 3, "Деснянський" },
                    { 4, "Дніпровський" },
                    { 5, "Печерський" },
                    { 6, "Оболонський" },
                    { 7, "Подільський" },
                    { 8, "Солом'янський" },
                    { 9, "Святошинський" },
                    { 10, "Шевченкивський" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "AreaName",
                table: "Users",
                newName: "Adress");
        }
    }
}
