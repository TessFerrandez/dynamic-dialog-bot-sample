using DynamicDialogApi.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicDialogApi.DataService
{
    public class DynamicDialogBotDbContext : DbContext
    {
        public DynamicDialogBotDbContext(DbContextOptions<DynamicDialogBotDbContext> options)
            : base(options)
        {
        }

        public DbSet<DbAction> Actions { get; set; }
        public DbSet<DbImage> Images { get; set; }
        public DbSet<DbLanguage> Languages { get; set; }
        public DbSet<DbLink> Links { get; set; }
        public DbSet<DbResponse> Responses { get; set; }
        public DbSet<DbResponseAction> ResponseActions { get; set; }
        public DbSet<DbText> Texts { get; set; }
        public DbSet<DbConfig> Configs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbResponseAction>()
                .HasKey(r => new { r.ResponseId, r.ActionId });
            modelBuilder.Entity<DbImage>()
                .HasKey(i => new { i.Id, i.LanguageId });
            modelBuilder.Entity<DbLink>()
                .HasKey(l => new { l.Id, l.LanguageId });
            modelBuilder.Entity<DbText>()
                .HasKey(t => new { t.Id, t.LanguageId, t.Ordinal });
        }

        public DbResponse GetResponse(string Id)
        {
            return Responses.Where(r => r.Id == Id).FirstOrDefault();
        }

        public IEnumerable<DbResponseAction> GetActionsForResponse(string responseId)
        {
            return ResponseActions.Where(r => r.ResponseId == responseId);
        }

        public DbAction GetAction(string actionId)
        {
            return Actions.Where(a => a.Id == actionId).FirstOrDefault();
        }

        public DbImage GetImage(string imageId, string languageId)
        {
            return Images.Where(i => i.Id == imageId && i.LanguageId == languageId).FirstOrDefault();
        }

        public DbLink GetLink(string linkId, string languageId)
        {
            return Links.Where(l => l.Id == linkId && l.LanguageId == languageId).FirstOrDefault();
        }

        public DbText GetText(string textId, string languageId)
        {
            var texts = Texts.Where(t => t.Id == textId && t.LanguageId == languageId);
            if (texts.Any())
            {
                Random r = new Random(/* TODO need random seed here */(int)DateTime.Now.Ticks);
                int ordinal = r.Next(texts.Count() - 1) + 1;
                return texts.Where(t => t.Ordinal == ordinal).FirstOrDefault();
            }
            else
                return null;
        }

        public DbConfig GetConfig()
        {
            // should only be one config
            return Configs.FirstOrDefault();
        }
    }
}
