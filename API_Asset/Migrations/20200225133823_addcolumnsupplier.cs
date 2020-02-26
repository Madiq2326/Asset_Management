using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Asset.Migrations
{
    public partial class addcolumnsupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tb_m_supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tb_m_supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "tb_m_supplier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "tb_m_supplier");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tb_m_supplier");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "tb_m_supplier");
        }
    }
}
