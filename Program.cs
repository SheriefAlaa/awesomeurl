using AwesomeUrl.Data;
using AwesomeUrl.GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ShortURLDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? "")
);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  options.RequireHttpsMetadata = false;
});
builder.
    Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

WebApplication app = builder.Build();

app.UseAuthentication();
app.MapGraphQL();
app.Run();