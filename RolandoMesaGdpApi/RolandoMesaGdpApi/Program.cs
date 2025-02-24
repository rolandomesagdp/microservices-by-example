var allowedOriginsPolicyName = "allowOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOriginsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "http://localhost:4201");
                      });
});

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(allowedOriginsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
