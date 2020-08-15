using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nekrasov.Demo.Storage.Migrations
{
    public partial class sqlserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PptxFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsPptx = table.Column<bool>(nullable: false),
                    WithVideo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PptxFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoFiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PptxFiles");

            migrationBuilder.DropTable(
                name: "VideoFiles");
        }
    }
}
