using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Government.Data.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValuetoadminresponsetext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponseText",
                table: "AdminResponses",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "No Admin Reasponse",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponseText",
                table: "AdminResponses",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldDefaultValue: "No Admin Reasponse");
        }
    }
}
