using Microsoft.EntityFrameworkCore.Migrations;

namespace Dell.Academy.Infra.Data.Migrations
{
    public partial class AddSkuColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "ProviderType",
                table: "Providers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderType",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
