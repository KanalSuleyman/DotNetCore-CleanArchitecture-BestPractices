using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestPractice.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleEntityCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SampleEntityCategoryId",
                table: "SampleEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SampleEntityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleEntityCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleEntities_SampleEntityCategoryId",
                table: "SampleEntities",
                column: "SampleEntityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleEntities_SampleEntityCategories_SampleEntityCategoryId",
                table: "SampleEntities",
                column: "SampleEntityCategoryId",
                principalTable: "SampleEntityCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleEntities_SampleEntityCategories_SampleEntityCategoryId",
                table: "SampleEntities");

            migrationBuilder.DropTable(
                name: "SampleEntityCategories");

            migrationBuilder.DropIndex(
                name: "IX_SampleEntities_SampleEntityCategoryId",
                table: "SampleEntities");

            migrationBuilder.DropColumn(
                name: "SampleEntityCategoryId",
                table: "SampleEntities");
        }
    }
}
