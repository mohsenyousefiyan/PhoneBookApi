using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.InfraStructures.DAL.EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GroupInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GroupInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PhoneNymberType",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    PhoneNymberTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PhoneNymberType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ContactGroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkGroupID = table.Column<int>(nullable: false),
                    LinkContactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ContactGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactGroup_Tbl_Contacts_LinkContactID",
                        column: x => x.LinkContactID,
                        principalTable: "Tbl_Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactGroup_Tbl_GroupInfo_LinkGroupID",
                        column: x => x.LinkGroupID,
                        principalTable: "Tbl_GroupInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ContactPhoneNumbers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkContactID = table.Column<int>(nullable: false),
                    LinkPhoneNumberTypeID = table.Column<byte>(nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ContactPhoneNumbers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactPhoneNumbers_Tbl_Contacts_LinkContactID",
                        column: x => x.LinkContactID,
                        principalTable: "Tbl_Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactPhoneNumbers_Tbl_PhoneNymberType_LinkPhoneNumberTypeID",
                        column: x => x.LinkPhoneNumberTypeID,
                        principalTable: "Tbl_PhoneNymberType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_PhoneNymberType",
                columns: new[] { "ID", "PhoneNymberTypeName" },
                values: new object[,]
                {
                    { (byte)1, "Mobile" },
                    { (byte)2, "Work" },
                    { (byte)3, "Home" },
                    { (byte)4, "Fax" },
                    { (byte)5, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactGroup_LinkContactID",
                table: "Tbl_ContactGroup",
                column: "LinkContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactGroup_LinkGroupID",
                table: "Tbl_ContactGroup",
                column: "LinkGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactPhoneNumbers_LinkContactID",
                table: "Tbl_ContactPhoneNumbers",
                column: "LinkContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactPhoneNumbers_LinkPhoneNumberTypeID",
                table: "Tbl_ContactPhoneNumbers",
                column: "LinkPhoneNumberTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ContactGroup");

            migrationBuilder.DropTable(
                name: "Tbl_ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Tbl_GroupInfo");

            migrationBuilder.DropTable(
                name: "Tbl_Contacts");

            migrationBuilder.DropTable(
                name: "Tbl_PhoneNymberType");
        }
    }
}
