using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinSpotAPI.Domain.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddOperationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_email",
                schema: "main",
                table: "users");

            migrationBuilder.CreateTable(
                name: "operations",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    expense_category = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operations", x => x.id);
                    table.ForeignKey(
                        name: "fk_operations_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "main",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                schema: "main",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_operations_amount",
                schema: "main",
                table: "operations",
                column: "amount");

            migrationBuilder.CreateIndex(
                name: "ix_operations_name",
                schema: "main",
                table: "operations",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_operations_user_id",
                schema: "main",
                table: "operations",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operations",
                schema: "main");

            migrationBuilder.DropIndex(
                name: "ix_users_email",
                schema: "main",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                schema: "main",
                table: "users",
                column: "email");
        }
    }
}
