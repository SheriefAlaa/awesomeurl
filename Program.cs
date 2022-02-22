using AwesomeUrl.Data;
using AwesomeUrl.GraphQL;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ShortURLDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? "")
);
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

WebApplication app = builder.Build();
app.MapGraphQL();
app.Run();