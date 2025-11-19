using ApplicationConnection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DbContext>();
builder.Services.Configure<ApplicationConfig>(builder.Configuration.GetSection("Configs"));
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<ApplicationConfig>>().Value);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();


