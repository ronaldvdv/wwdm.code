using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WWDM.GraphQL.DataLoaders;
using WWDM.GraphQL.Schema;

namespace WWDM.GraphQL
{
    public class Startup
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddDebug().AddConsole(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"Environment: {env.EnvironmentName}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddDataLoader<SeasonByIdDataLoader>()
                .AddDataLoader<EpisodeByIdDataLoader>()
                .AddDataLoader<ParticipantByIdDataLoader>()
                .AddDataLoader<GameByIdDataLoader>()
                .AddType<SeasonType>()
                .AddType<EpisodeType>()
                .AddType<GameType>()
                .AddType<ImageType>();
            var cs = Configuration.GetConnectionString("Database");
            services.AddPooledDbContextFactory<WWDMContext>(dbob =>
            {
                dbob.UseMySql(cs, ServerVersion.AutoDetect(cs));
                dbob.UseLoggerFactory(loggerFactory);
            });
        }
    }
}