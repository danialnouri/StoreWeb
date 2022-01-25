using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class order_table_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kalas",
                columns: table => new
                {
                    KalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalaPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalas", x => x.KalaId);
                });

            migrationBuilder.CreateTable(
                name: "OrderApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KalaId = table.Column<int>(type: "int", nullable: false),
                    Tedad = table.Column<int>(type: "int", nullable: false),
                    KalaPrice = table.Column<int>(type: "int", nullable: false),
                    KalaAll = table.Column<int>(type: "int", nullable: false),
                    DateSabt = table.Column<int>(type: "int", nullable: false),
                    TimeSabt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderApps_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderApps_Kalas_KalaId",
                        column: x => x.KalaId,
                        principalTable: "Kalas",
                        principalColumn: "KalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderApps_CustomerId",
                table: "OrderApps",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderApps_KalaId",
                table: "OrderApps",
                column: "KalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderApps");

            migrationBuilder.DropTable(
                name: "Kalas");
        }
    }
}
