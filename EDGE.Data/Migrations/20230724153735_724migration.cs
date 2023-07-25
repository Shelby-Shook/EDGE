using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGE.Data.Migrations
{
    /// <inheritdoc />
    public partial class _724migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_UserId",
                schema: "EDGESchema",
                table: "WorkoutLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_UserId",
                schema: "EDGESchema",
                table: "PersonalRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalRecords_Users_UserId",
                schema: "EDGESchema",
                table: "PersonalRecords",
                column: "UserId",
                principalSchema: "EDGESchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLog_Users_UserId",
                schema: "EDGESchema",
                table: "WorkoutLog",
                column: "UserId",
                principalSchema: "EDGESchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalRecords_Users_UserId",
                schema: "EDGESchema",
                table: "PersonalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLog_Users_UserId",
                schema: "EDGESchema",
                table: "WorkoutLog");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutLog_UserId",
                schema: "EDGESchema",
                table: "WorkoutLog");

            migrationBuilder.DropIndex(
                name: "IX_PersonalRecords_UserId",
                schema: "EDGESchema",
                table: "PersonalRecords");
        }
    }
}
