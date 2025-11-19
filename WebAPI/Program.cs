using DefaultNamespace;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:7000");
builder.Services.AddControllers();
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.Configure<ApplicationConfig>(builder.Configuration.GetSection("Configs"));
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<ApplicationConfig>>().Value);
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
        RequestPath = new PathString("/Uploads"),
        ServeUnknownFileTypes = true,
        OnPrepareResponse = ctx =>
            ctx.Context.Response.Headers.Append(
                "Cache-Control", $"public, max-age={604800}")
    });
app.MapControllers();
app.Run();