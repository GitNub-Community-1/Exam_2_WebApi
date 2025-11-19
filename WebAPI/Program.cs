using DefaultNamespace;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.Configure<ApplicationConfig>(builder.Configuration.GetSection("Configs"));
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<ApplicationConfig>>().Value);
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


