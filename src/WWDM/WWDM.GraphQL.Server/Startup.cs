using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WWDM.GraphQL.Types;

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
            app.UseWebSockets()
                .UseGraphQL("/graphql")
                .UsePlayground("/graphql", "/graphqlplayground")
                .UseVoyager("/graphql", "/graphqlvoyager");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(
                sp => SchemaBuilder.New()
                .AddServices(sp)
                .AddQueryType<QueryType>()
                .AddType<EpisodeType>()
                .AddType<SeasonType>()
                .Create()
            );
            services.AddGraphQLSubscriptions();
            services.AddDataLoaderRegistry();
            var cs = "Server=localhost;Database=wwdm2020;Uid=root;Pwd=root;";
            services.AddDbContext<WWDMContext>(dbob => dbob.UseMySql(cs));
        }
    }
}