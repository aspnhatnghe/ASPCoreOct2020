using Microsoft.EntityFrameworkCore.Migrations;

namespace Day15_EFCore.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlInsertData = @"
        INSERT INTO Loai(TenLoai, MoTa) VALUES
            (N'Bia', N'Bia đủ loại'),
            (N'Laptop', N'Laptop')
    ";
            migrationBuilder.Sql(sqlInsertData);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
