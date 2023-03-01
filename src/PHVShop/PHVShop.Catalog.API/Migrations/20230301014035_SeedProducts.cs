using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHVShop.Catalog.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Caderno',7.55,'Caderno Espiral',10,'caderno1.jpg',1)");

            migrationBuilder.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Lápis',3.45,'Lápis Preto',20,'lapis1.jpg',1)");

            migrationBuilder.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Clips',5.33,'Clips para papel',50,'clips1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
