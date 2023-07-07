using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_TASK1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dirs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirs", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "DirRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Parent = table.Column<int>(type: "int", nullable: false),
                    Id_Child = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirRelations_Dirs_Id_Child",
                        column: x => x.Id_Child,
                        principalTable: "Dirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirRelations_Dirs_Id_Parent",
                        column: x => x.Id_Parent,
                        principalTable: "Dirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirRelations_Id_Child",
                table: "DirRelations",
                column: "Id_Child");

            migrationBuilder.CreateIndex(
                name: "IX_DirRelations_Id_Parent",
                table: "DirRelations",
                column: "Id_Parent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirRelations");

            migrationBuilder.DropTable(
                name: "Dirs");
        }
    }
}
