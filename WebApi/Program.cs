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

// Add DALs
builder.Services.AddHttpClient<IMoviesService, ImdbApiMoviesService>();

// Add BLs
builder.Services.AddScoped<IBLMovies, BLMovies>();

// CORS Policiies
var AllowAllCors = "_allowAllCors";
builder.Services.AddCors(
    options => options.AddPolicy(
        name: AllowAllCors,
        builder => builder
            .AllowAnyOrigin() // .WithOrigins("http://localhost:8080")
            .AllowAnyMethod()
            .AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(AllowAllCors);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
