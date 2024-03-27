using Odyssey.MusicMatcher;
using SpotifyWeb;

/// <summary>
/// Creating a web application builder.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Adding HttpClient for SpotifyService.
/// Added automatically via nswag
/// Swagger file was included in the documentation
/// </summary>
builder.Services.AddHttpClient<SpotifyService>();

/// <summary>
/// Adding GraphQL server.
/// </summary>
builder.Services.AddGraphQLServer()
      .AddQueryType<Query>()
      .AddMutationType<Mutation>()
      .RegisterService<SpotifyService>();

/// <summary>
/// Adding CORS (Cross-Origin Resource Sharing) policy.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("https://studio.apollographql.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

/// <summary>
/// Enabling CORS.
/// </summary>
app.UseCors();

/// <summary>
/// Mapping GraphQL endpoint.
/// </summary>
app.MapGraphQL();

app.Run();
