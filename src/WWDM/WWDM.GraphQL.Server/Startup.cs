using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WWDM.GraphQL.DataLoaders;
using WWDM.GraphQL.Schema;

namespace WWDM.GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                .AddDataLoader<SeasonByIdDataLoader>();
            var cs = "Server=localhost;Database=wwdm2020;Uid=root;Pwd=root;";
            services.AddPooledDbContextFactory<WWDMContext>(dbob => dbob.UseMySql(cs, ServerVersion.AutoDetect(cs)));
        }
    }
}