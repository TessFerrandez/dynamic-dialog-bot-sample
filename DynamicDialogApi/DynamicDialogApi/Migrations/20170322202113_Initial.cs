using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicDialogApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageId = table.Column<string>(nullable: true),
                    NextResponseId = table.Column<string>(nullable: true),
                    ShortActionTextId = table.Column<string>(nullable: true),
                    SideEffects = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    TextId = table.Column<string>(nullable: true),
                    TrackingTags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DefaultActionId = table.Column<string>(nullable: true),
                    DefaultResponseId = table.Column<string>(nullable: true),
                    ErrorResponseId = table.Column<string>(nullable: true),
                    ReplayResponseId = table.Column<string>(nullable: true),
                    StartActionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LanguageId = table.Column<string>(nullable: false),
                    IsAnimated = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => new { x.Id, x.LanguageId });
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LanguageId = table.Column<string>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => new { x.Id, x.LanguageId });
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageId = table.Column<string>(nullable: true),
                    IncludeDefaultAction = table.Column<bool>(nullable: false),
                    LinkId = table.Column<string>(nullable: true),
                    MediaType = table.Column<string>(nullable: true),
                    SearchHitTextId = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    TextId = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseActions",
                columns: table => new
                {
                    ResponseId = table.Column<string>(nullable: false),
                    ActionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseActions", x => new { x.ResponseId, x.ActionId });
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LanguageId = table.Column<string>(nullable: false),
                    Ordinal = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => new { x.Id, x.LanguageId, x.Ordinal });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "ResponseActions");

            migrationBuilder.DropTable(
                name: "Texts");
        }
    }
}
