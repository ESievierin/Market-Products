using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Products.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageKeytoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageKey",
                table: "Products",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageKey",
                table: "Products");
        }
    }
}
