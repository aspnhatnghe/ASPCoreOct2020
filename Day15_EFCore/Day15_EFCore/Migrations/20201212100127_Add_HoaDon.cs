using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Day15_EFCore.Migrations
{
    public partial class Add_HoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    MaHd = table.Column<Guid>(nullable: false),
                    MaKH = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(maxLength: 150, nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.MaHd);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    MaHd = table.Column<Guid>(nullable: false),
                    MaHh = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.MaHd, x.MaHh });
                    table.ForeignKey(
                        name: "FK_CTHD_HD",
                        column: x => x.MaHd,
                        principalTable: "Order",
                        principalColumn: "MaHd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_HangHoa_MaHh",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_MaHh",
                table: "OrderDetail",
                column: "MaHh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
