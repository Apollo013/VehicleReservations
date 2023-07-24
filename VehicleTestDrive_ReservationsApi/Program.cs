using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_ReservationsApi.Data;
using VehicleTestDrive_ReservationsApi.Repository;
using VehicleTestDrive_ReservationsApi.Repository.Contracts;
using VehicleTestDrive_ReservationsApi.Services;
using VehicleTestDrive_ReservationsApi.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection"));
});

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationBusService, ReservationBusService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IReservationService, ReservationService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
