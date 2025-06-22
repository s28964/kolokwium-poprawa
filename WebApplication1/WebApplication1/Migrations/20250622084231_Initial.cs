using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearCreated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.ArtworkId);
                    table.ForeignKey(
                        name: "FK_Artwork_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfArtworks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ExhibitionId);
                    table.ForeignKey(
                        name: "FK_Exhibition_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition_Artwork",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition_Artwork", x => new { x.ExhibitionId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_Exhibition_Artwork_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "ArtworkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibition_Artwork_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "ExhibitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Slow" },
                    { 2, new DateTime(1994, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jenna", "Green" },
                    { 3, new DateTime(1978, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Gallery",
                columns: new[] { "GalleryId", "EstablishmentDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1968, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gallery1" },
                    { 2, new DateTime(1976, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gallery2" },
                    { 3, new DateTime(1991, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gallery3" }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "ArtworkId", "ArtistId", "Title", "YearCreated" },
                values: new object[,]
                {
                    { 1, 1, "Artwork1", 2022 },
                    { 2, 2, "Artwork2", 2019 },
                    { 3, 3, "Artwork3", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "ExhibitionId", "EndDate", "GalleryId", "NumberOfArtworks", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exhibition1" },
                    { 2, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exhibition2" },
                    { 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 15, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exhibition3" }
                });

            migrationBuilder.InsertData(
                table: "Exhibition_Artwork",
                columns: new[] { "ArtworkId", "ExhibitionId", "InsuranceValue" },
                values: new object[,]
                {
                    { 1, 1, 10000m },
                    { 2, 2, 20000m },
                    { 3, 3, 30000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_ArtistId",
                table: "Artwork",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_GalleryId",
                table: "Exhibition",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_Artwork_ArtworkId",
                table: "Exhibition_Artwork",
                column: "ArtworkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exhibition_Artwork");

            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Gallery");
        }
    }
}
