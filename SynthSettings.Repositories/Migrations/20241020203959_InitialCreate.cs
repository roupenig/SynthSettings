using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SynthSettings.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADSRs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Attack = table.Column<int>(type: "integer", nullable: false),
                    Delay = table.Column<int>(type: "integer", nullable: false),
                    Sustain = table.Column<int>(type: "integer", nullable: false),
                    Release = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADSRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oscillators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Pitch = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oscillators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Envelopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amplitude = table.Column<int>(type: "integer", nullable: false),
                    ADSRId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envelopes_ADSRs_ADSRId",
                        column: x => x.ADSRId,
                        principalTable: "ADSRs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Cutoff = table.Column<int>(type: "integer", nullable: false),
                    Resonance = table.Column<int>(type: "integer", nullable: false),
                    ADSRId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_ADSRs_ADSRId",
                        column: x => x.ADSRId,
                        principalTable: "ADSRs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OscillatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnvelopeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilterId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Oscillators_OscillatorId",
                        column: x => x.OscillatorId,
                        principalTable: "Oscillators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envelopes_ADSRId",
                table: "Envelopes",
                column: "ADSRId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_ADSRId",
                table: "Filters",
                column: "ADSRId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_EnvelopeId",
                table: "Settings",
                column: "EnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_FilterId",
                table: "Settings",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_OscillatorId",
                table: "Settings",
                column: "OscillatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Envelopes");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Oscillators");

            migrationBuilder.DropTable(
                name: "ADSRs");
        }
    }
}
