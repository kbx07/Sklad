using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklad.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Condition_ConditionId",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_ExactLocation_ExactLocationId",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Location_LocationId",
                table: "Tool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tool",
                table: "Tool");

            migrationBuilder.RenameTable(
                name: "Tool",
                newName: "tool");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "tool",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "ExactLocationId",
                table: "tool",
                newName: "exactlocation_id");

            migrationBuilder.RenameColumn(
                name: "ConditionId",
                table: "tool",
                newName: "condition_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_LocationId",
                table: "tool",
                newName: "IX_tool_location_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_ExactLocationId",
                table: "tool",
                newName: "IX_tool_exactlocation_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_ConditionId",
                table: "tool",
                newName: "IX_tool_condition_id");

            migrationBuilder.AlterColumn<int>(
                name: "location_id",
                table: "tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "exactlocation_id",
                table: "tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "condition_id",
                table: "tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tool",
                table: "tool",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tool_Condition_condition_id",
                table: "tool",
                column: "condition_id",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tool_ExactLocation_exactlocation_id",
                table: "tool",
                column: "exactlocation_id",
                principalTable: "ExactLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tool_Location_location_id",
                table: "tool",
                column: "location_id",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tool_Condition_condition_id",
                table: "tool");

            migrationBuilder.DropForeignKey(
                name: "FK_tool_ExactLocation_exactlocation_id",
                table: "tool");

            migrationBuilder.DropForeignKey(
                name: "FK_tool_Location_location_id",
                table: "tool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tool",
                table: "tool");

            migrationBuilder.RenameTable(
                name: "tool",
                newName: "Tool");

            migrationBuilder.RenameColumn(
                name: "location_id",
                table: "Tool",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "exactlocation_id",
                table: "Tool",
                newName: "ExactLocationId");

            migrationBuilder.RenameColumn(
                name: "condition_id",
                table: "Tool",
                newName: "ConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_tool_location_id",
                table: "Tool",
                newName: "IX_Tool_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_tool_exactlocation_id",
                table: "Tool",
                newName: "IX_Tool_ExactLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_tool_condition_id",
                table: "Tool",
                newName: "IX_Tool_ConditionId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ExactLocationId",
                table: "Tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionId",
                table: "Tool",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tool",
                table: "Tool",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Condition_ConditionId",
                table: "Tool",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_ExactLocation_ExactLocationId",
                table: "Tool",
                column: "ExactLocationId",
                principalTable: "ExactLocation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Location_LocationId",
                table: "Tool",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }
    }
}
