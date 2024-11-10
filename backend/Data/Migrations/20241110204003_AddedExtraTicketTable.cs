using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraTicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedTicketIds",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "TicketRelationships",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedTicketId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRelationships", x => new { x.TicketId, x.RelatedTicketId });
                    table.ForeignKey(
                        name: "FK_TicketRelationships_Tickets_RelatedTicketId",
                        column: x => x.RelatedTicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketRelationships_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelationships_RelatedTicketId",
                table: "TicketRelationships",
                column: "RelatedTicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketRelationships");

            migrationBuilder.AddColumn<string>(
                name: "AttachedTicketIds",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
