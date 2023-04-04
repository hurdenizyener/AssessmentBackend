using Business;
using DataAccess;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Logger log = new LoggerConfiguration()
   .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day).MinimumLevel //Herg�n i�in bir dosya �retecek
   .Information()
   .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
