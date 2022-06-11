using WebApi.BL.Contracts;
using WebApi.BL.Implementation;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DALs
builder.Services.AddHttpClient<IMoviesService, ImdbApiMoviesService>();

// BLs
builder.Services.AddScoped<IBLMovies, BLMovies>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
