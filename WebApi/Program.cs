using Microsoft.EntityFrameworkCore;
using WebApi.BL.Contracts;
using WebApi.BL.Implementation;
using WebApi.DAL.Contexts;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DALs
builder.Services.AddScoped<IDALDepartments, DALDepartments>();

// Add BLs
builder.Services.AddScoped<IBLDepartments, BLDepartments>();

// DB stuff
builder.Services.AddDbContext<MainContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"))
);

var AllowAllCors = "_allowAllCors";
builder.Services.AddCors(
    options => options.AddPolicy(
        name: AllowAllCors,
        builder => builder
            .AllowAnyOrigin() // .WithOrigins("http://localhost:8080")
            .AllowAnyMethod()
            .AllowAnyHeader())
);

// Response Caching Middleware
builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    app.UseDeveloperExceptionPage();
    app.UseCors(AllowAllCors);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

//app.Use(async (context, next) =>
//{
//    context.Response.GetTypedHeaders().CacheControl =
//        new CacheControlHeaderValue()
//        {
//            Public = true,
//            MaxAge = TimeSpan.FromHours(1)
//        };
//    await next();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
