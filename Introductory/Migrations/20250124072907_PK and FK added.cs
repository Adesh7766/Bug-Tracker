using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class PKandFKadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainStatusID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainStatusTrackInfo_ComplainStatus_ComplainStatusID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainStatusID",
                principalTable: "ComplainStatus",
                principalColumn: "ComplainStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainStatusTrackInfo_Complain_ComplainID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainID",
                principalTable: "Complain",
                principalColumn: "ComplainId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainStatusTrackInfo_ComplainStatus_ComplainStatusID",
                table: "ComplainStatusTrackInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplainStatusTrackInfo_Complain_ComplainID",
                table: "ComplainStatusTrackInfo");

            migrationBuilder.DropIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainID",
                table: "ComplainStatusTrackInfo");

            migrationBuilder.DropIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainStatusID",
                table: "ComplainStatusTrackInfo");
        }
    }
}
