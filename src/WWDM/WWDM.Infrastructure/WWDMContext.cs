using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWDM.Models;
using WWDM.Models.Configurations;

namespace WWDM
{
    public class WWDMContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        public WWDMContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Suspicion> Suspicions { get; set; }
        public DbSet<TagGroup> TagGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Website> Websites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
            .UseLoggerFactory(loggerFactory)
            .UseLazyLoadingProxies()
            ;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new GameTagConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new WebsiteConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());

            SetupNamingConventions(modelBuilder);
        }

        protected void SetupNamingConventions(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                if (entity.BaseType == null)
                {
                    entity.SetTableName(entity.GetTableName().ToSnakeCase());
                }

                // Replace column names
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }
    }
}