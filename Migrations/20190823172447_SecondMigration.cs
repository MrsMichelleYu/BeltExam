using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Act_Users_UserId",
                table: "Act");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedActivity_Act_ActivityId",
                table: "JoinedActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedActivity_Users_UserId",
                table: "JoinedActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinedActivity",
                table: "JoinedActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Act",
                table: "Act");

            migrationBuilder.RenameTable(
                name: "JoinedActivity",
                newName: "JoinedActivities");

            migrationBuilder.RenameTable(
                name: "Act",
                newName: "Acts");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedActivity_UserId",
                table: "JoinedActivities",
                newName: "IX_JoinedActivities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedActivity_ActivityId",
                table: "JoinedActivities",
                newName: "IX_JoinedActivities_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Act_UserId",
                table: "Acts",
                newName: "IX_Acts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinedActivities",
                table: "JoinedActivities",
                column: "JoinedActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acts",
                table: "Acts",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_Users_UserId",
                table: "Acts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedActivities_Acts_ActivityId",
                table: "JoinedActivities",
                column: "ActivityId",
                principalTable: "Acts",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedActivities_Users_UserId",
                table: "JoinedActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_Users_UserId",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedActivities_Acts_ActivityId",
                table: "JoinedActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedActivities_Users_UserId",
                table: "JoinedActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinedActivities",
                table: "JoinedActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acts",
                table: "Acts");

            migrationBuilder.RenameTable(
                name: "JoinedActivities",
                newName: "JoinedActivity");

            migrationBuilder.RenameTable(
                name: "Acts",
                newName: "Act");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedActivities_UserId",
                table: "JoinedActivity",
                newName: "IX_JoinedActivity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedActivities_ActivityId",
                table: "JoinedActivity",
                newName: "IX_JoinedActivity_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Acts_UserId",
                table: "Act",
                newName: "IX_Act_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinedActivity",
                table: "JoinedActivity",
                column: "JoinedActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Act",
                table: "Act",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Act_Users_UserId",
                table: "Act",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedActivity_Act_ActivityId",
                table: "JoinedActivity",
                column: "ActivityId",
                principalTable: "Act",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedActivity_Users_UserId",
                table: "JoinedActivity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
