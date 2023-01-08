using CRUD_API.Repositories.Contacts;
using CRUD_API.Repositories.Locations;
using CRUD_API.Repositories.Phones;
using CRUD_API.Services;
using CRUD_API.SQL;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => options
    .UseSqlServer(builder.Configuration
        .GetConnectionString("CRUD_API_ConnectionString")));

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IPhoneTypeRepository, PhoneTypeRepository>();

builder.Services.AddScoped<IPhoneTypeService, PhoneTypeService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
