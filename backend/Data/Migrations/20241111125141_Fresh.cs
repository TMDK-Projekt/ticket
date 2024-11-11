using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Fresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketRelationships_Tickets_TicketId",
                table: "TicketRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketRelationships",
                table: "TicketRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TicketRelationships_TicketId",
                table: "TicketRelationships");

            migrationBuilder.DropColumn(
                name: "InitialTicketId",
                table: "TicketRelationships");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketRelationships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketRelationships",
                table: "TicketRelationships",
                columns: new[] { "TicketId", "RelatedTicketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketRelationships_Tickets_TicketId",
                table: "TicketRelationships",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketRelationships_Tickets_TicketId",
                table: "TicketRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketRelationships",
                table: "TicketRelationships");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketRelationships",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "InitialTicketId",
                table: "TicketRelationships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketRelationships",
                table: "TicketRelationships",
                columns: new[] { "InitialTicketId", "RelatedTicketId" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelationships_TicketId",
                table: "TicketRelationships",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketRelationships_Tickets_TicketId",
                table: "TicketRelationships",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
