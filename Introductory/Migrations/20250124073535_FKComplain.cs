using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class FKComplain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Complain_ComplainTypeId",
                table: "Complain",
                column: "ComplainTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complain_ComplainType_ComplainTypeId",
                table: "Complain",
                column: "ComplainTypeId",
                principalTable: "ComplainType",
                principalColumn: "ComplainTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complain_ComplainType_ComplainTypeId",
                table: "Complain");

            migrationBuilder.DropIndex(
                name: "IX_Complain_ComplainTypeId",
                table: "Complain");
        }
    }
}
