var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();


app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Welcome to LDAP connectivity test. Kindly use URL: /search");
});

app.Run();
