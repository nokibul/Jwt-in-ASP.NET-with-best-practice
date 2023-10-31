using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agency.Migrations
{
    /// <inheritdoc />
    public partial class removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Agencies_AgencyId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_AgencyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "AgencyEntityId",
                table: "Members",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_AgencyEntityId",
                table: "Members",
                column: "AgencyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Agencies_AgencyEntityId",
                table: "Members",
                column: "AgencyEntityId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Agencies_AgencyEntityId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_AgencyEntityId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AgencyEntityId",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "AgencyId",
                table: "Members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Members_AgencyId",
                table: "Members",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Agencies_AgencyId",
                table: "Members",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
