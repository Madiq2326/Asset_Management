using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Asset.Migrations
{
    public partial class renametableinc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Item_TB_M_Brand_Brand_id",
                table: "TB_M_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Item_TB_M_Supplier_Supplier_id",
                table: "TB_M_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_Incominitem_TB_M_Item_Item_id",
                table: "TB_R_Incominitem");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Item_Brand_id",
                table: "TB_M_Item");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Item_Supplier_id",
                table: "TB_M_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_R_Incominitem",
                table: "TB_R_Incominitem");

            migrationBuilder.RenameTable(
                name: "TB_R_Incominitem",
                newName: "TB_R_Incomingitem");

            migrationBuilder.RenameIndex(
                name: "IX_TB_R_Incominitem_Item_id",
                table: "TB_R_Incomingitem",
                newName: "IX_TB_R_Incomingitem_Item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_R_Incomingitem",
                table: "TB_R_Incomingitem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_Incomingitem_TB_M_Item_Item_id",
                table: "TB_R_Incomingitem",
                column: "Item_id",
                principalTable: "TB_M_Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_Incomingitem_TB_M_Item_Item_id",
                table: "TB_R_Incomingitem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_R_Incomingitem",
                table: "TB_R_Incomingitem");

            migrationBuilder.RenameTable(
                name: "TB_R_Incomingitem",
                newName: "TB_R_Incominitem");

            migrationBuilder.RenameIndex(
                name: "IX_TB_R_Incomingitem_Item_id",
                table: "TB_R_Incominitem",
                newName: "IX_TB_R_Incominitem_Item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_R_Incominitem",
                table: "TB_R_Incominitem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Item_Brand_id",
                table: "TB_M_Item",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Item_Supplier_id",
                table: "TB_M_Item",
                column: "Supplier_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Item_TB_M_Brand_Brand_id",
                table: "TB_M_Item",
                column: "Brand_id",
                principalTable: "TB_M_Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Item_TB_M_Supplier_Supplier_id",
                table: "TB_M_Item",
                column: "Supplier_id",
                principalTable: "TB_M_Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_Incominitem_TB_M_Item_Item_id",
                table: "TB_R_Incominitem",
                column: "Item_id",
                principalTable: "TB_M_Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
