using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DynamicDialogApi.DataService;

namespace DynamicDialogApi.Migrations
{
    [DbContext(typeof(DynamicDialogBotDbContext))]
    [Migration("20170322202113_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbAction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageId");

                    b.Property<string>("NextResponseId");

                    b.Property<string>("ShortActionTextId");

                    b.Property<string>("SideEffects");

                    b.Property<string>("Slug");

                    b.Property<string>("TextId");

                    b.Property<string>("TrackingTags");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DefaultActionId");

                    b.Property<string>("DefaultResponseId");

                    b.Property<string>("ErrorResponseId");

                    b.Property<string>("ReplayResponseId");

                    b.Property<string>("StartActionId");

                    b.HasKey("Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbImage", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("LanguageId");

                    b.Property<bool>("IsAnimated");

                    b.Property<string>("Url");

                    b.HasKey("Id", "LanguageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbLanguage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbLink", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("LanguageId");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id", "LanguageId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbResponse", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageId");

                    b.Property<bool>("IncludeDefaultAction");

                    b.Property<string>("LinkId");

                    b.Property<string>("MediaType");

                    b.Property<string>("SearchHitTextId");

                    b.Property<string>("Slug");

                    b.Property<string>("TextId");

                    b.Property<string>("VideoId");

                    b.HasKey("Id");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbResponseAction", b =>
                {
                    b.Property<string>("ResponseId");

                    b.Property<string>("ActionId");

                    b.HasKey("ResponseId", "ActionId");

                    b.ToTable("ResponseActions");
                });

            modelBuilder.Entity("DynamicDialogApi.Models.Data.DbText", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("LanguageId");

                    b.Property<int>("Ordinal");

                    b.Property<string>("Content");

                    b.HasKey("Id", "LanguageId", "Ordinal");

                    b.ToTable("Texts");
                });
        }
    }
}
