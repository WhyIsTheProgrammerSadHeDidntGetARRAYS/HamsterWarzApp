using HamsterWarz.API.Data;
using HamsterWarz.API.Data.Interfaces;
using HamsterWarz.API.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adding database connection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//enabling cors for client side url
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:7236",
            "http://localhost:5236");
        });
});


builder.Services.AddScoped<IHamsterService, HamsterService>();
builder.Services.AddScoped<IMatchDataService, MatchDataService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
// Seeding the database
AppDbInitializer.Initialize(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
