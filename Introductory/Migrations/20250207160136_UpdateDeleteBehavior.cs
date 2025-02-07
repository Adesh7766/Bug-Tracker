using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplainType",
                columns: table => new
                {
                    ComplainTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainType", x => x.ComplainTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Complain",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complain", x => x.ComplainId);
                    table.ForeignKey(
                        name: "FK_Complain_ComplainType_ComplainTypeId",
                        column: x => x.ComplainTypeId,
                        principalTable: "ComplainType",
                        principalColumn: "ComplainTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplainStatus",
                columns: table => new
                {
                    ComplainStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainStatus", x => x.ComplainStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ComplainStatusTrackInfo",
                columns: table => new
                {
                    ComplainStatusTrackInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainID = table.Column<int>(type: "int", nullable: false),
                    ComplainStatusID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainStatusTrackInfo", x => x.ComplainStatusTrackInfoID);
                    table.ForeignKey(
                        name: "FK_ComplainStatusTrackInfo_ComplainStatus_ComplainStatusID",
                        column: x => x.ComplainStatusID,
                        principalTable: "ComplainStatus",
                        principalColumn: "ComplainStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplainStatusTrackInfo_Complain_ComplainID",
                        column: x => x.ComplainID,
                        principalTable: "Complain",
                        principalColumn: "ComplainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "UserGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complain_ComplainTypeId",
                table: "Complain",
                column: "ComplainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatus_CreatedBy",
                table: "ComplainStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainStatusID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_CreatedBy",
                table: "ComplainStatusTrackInfo",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_CreatedBy",
                table: "UserGroup",
                column: "CreatedBy",
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainStatus_Users_CreatedBy",
                table: "ComplainStatus",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainStatusTrackInfo_Users_CreatedBy",
                table: "ComplainStatusTrackInfo",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_CreatedBy",
                table: "UserGroup",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_CreatedBy",
                table: "UserGroup");

            migrationBuilder.DropTable(
                name: "ComplainStatusTrackInfo");

            migrationBuilder.DropTable(
                name: "ComplainStatus");

            migrationBuilder.DropTable(
                name: "Complain");

            migrationBuilder.DropTable(
                name: "ComplainType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroup");
        }
    }
}
