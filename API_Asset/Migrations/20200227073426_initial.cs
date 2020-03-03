using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Asset.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roleclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roleclaims_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Brand_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Item_TB_M_Brand_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "TB_M_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userclaims_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userlogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_userlogins_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userroles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_userroles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userroles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usertokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usertokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usertokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Lend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Employee_id = table.Column<int>(nullable: false),
                    Lend_Date = table.Column<DateTime>(nullable: false),
                    Approve_Date_1 = table.Column<DateTime>(nullable: false),
                    Approve_Date_2 = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Damage_Level = table.Column<string>(nullable: true),
                    Damage_Type = table.Column<string>(nullable: true),
                    Item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Lend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Lend_TB_M_Item_Item_id",
                        column: x => x.Item_id,
                        principalTable: "TB_M_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Approve_Date_1 = table.Column<DateTime>(nullable: false),
                    Approve_Date_2 = table.Column<DateTime>(nullable: false),
                    Brand_id = table.Column<int>(nullable: false),
                    Item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Request_TB_M_Brand_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "TB_M_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Request_TB_M_Item_Item_id",
                        column: x => x.Item_id,
                        principalTable: "TB_M_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_R_Incominitem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Incoming_date = table.Column<DateTime>(nullable: false),
                    Supplier_id = table.Column<int>(nullable: false),
                    Item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_R_Incominitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_R_Incominitem_TB_M_Item_Item_id",
                        column: x => x.Item_id,
                        principalTable: "TB_M_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_R_Incominitem_TB_M_Supplier_Supplier_id",
                        column: x => x.Supplier_id,
                        principalTable: "TB_M_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_R_Outgoingitem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Outgoing_Date = table.Column<DateTime>(nullable: false),
                    Item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_R_Outgoingitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_R_Outgoingitem_TB_M_Item_Item_id",
                        column: x => x.Item_id,
                        principalTable: "TB_M_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roleclaims_RoleId",
                table: "roleclaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Item_Brand_id",
                table: "TB_M_Item",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Lend_Item_id",
                table: "TB_M_Lend",
                column: "Item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Request_Brand_id",
                table: "TB_M_Request",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Request_Item_id",
                table: "TB_M_Request",
                column: "Item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_Incominitem_Item_id",
                table: "TB_R_Incominitem",
                column: "Item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_Incominitem_Supplier_id",
                table: "TB_R_Incominitem",
                column: "Supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_Outgoingitem_Item_id",
                table: "TB_R_Outgoingitem",
                column: "Item_id");

            migrationBuilder.CreateIndex(
                name: "IX_userclaims_UserId",
                table: "userclaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userlogins_UserId",
                table: "userlogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userroles_RoleId",
                table: "userroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roleclaims");

            migrationBuilder.DropTable(
                name: "TB_M_Lend");

            migrationBuilder.DropTable(
                name: "TB_M_Request");

            migrationBuilder.DropTable(
                name: "TB_R_Incominitem");

            migrationBuilder.DropTable(
                name: "TB_R_Outgoingitem");

            migrationBuilder.DropTable(
                name: "userclaims");

            migrationBuilder.DropTable(
                name: "userlogins");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropTable(
                name: "usertokens");

            migrationBuilder.DropTable(
                name: "TB_M_Supplier");

            migrationBuilder.DropTable(
                name: "TB_M_Item");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "TB_M_Brand");
        }
    }
}
