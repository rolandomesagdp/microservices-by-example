using Microsoft.EntityFrameworkCore;
using TrafficFine.Api.FineContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ExternalFactorsDb");
builder.Services.AddDbContext<ExternalFactorsDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

var app = builder.Build();

// Creating and seeding the data
using (var scope = app.Services.CreateScope())
{
    var fineContext = scope.ServiceProvider.GetRequiredService<ExternalFactorsDbContext>();
    fineContext.Database.EnsureCreated();
    fineContext.Seed();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
