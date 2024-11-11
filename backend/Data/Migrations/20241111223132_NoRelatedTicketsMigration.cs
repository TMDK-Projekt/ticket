using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NoRelatedTicketsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketRelationships");

            migrationBuilder.AddColumn<int>(
                name: "RelatedTicketsId",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RelatedTicketsId",
                table: "Tickets",
                column: "RelatedTicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tickets_RelatedTicketsId",
                table: "Tickets",
                column: "RelatedTicketsId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tickets_RelatedTicketsId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RelatedTicketsId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RelatedTicketsId",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "TicketRelationships",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    RelatedTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    RelationshipDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRelationships", x => new { x.TicketId, x.RelatedTicketId });
                    table.ForeignKey(
                        name: "FK_TicketRelationships_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
