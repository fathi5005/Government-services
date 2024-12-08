using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Government.Data.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValuetoadminresponsetext1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponseText",
                table: "AdminResponses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "No Admin Reasponse",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldDefaultValue: "No Admin Reasponse");
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
                defaultValue: "No Admin Reasponse",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "No Admin Reasponse");
        }
    }
}
