using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Asset.Migrations
{
    public partial class changetypetotypeitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tb_m_item",
                newName: "Type_Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type_Item",
                table: "tb_m_item",
                newName: "Type");
        }
    }
}
