using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.BL.Contracts;
using WebApi.BL.Implementation;
using WebApi.DAL.Contracts;
using WebApi.DAL.Helpers;
using WebApi.DAL.Implementation;
using WebApi.DAL.Implementation.Contexts;
using WebApi.DAL.Implementation.Initializers;
using WebApi.DAL.Repos.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); // https://stackoverflow.com/a/59807536
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DALs
//builder.Services.AddScoped<IDALDepartments, DALDepartments>();
//builder.Services.AddScoped<IDALWorkers, DALWorkers>();
builder.Services.AddScoped<IGenericRepo, GenericRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();

// Add BLs
builder.Services.AddScoped<IBLDepartments, BLDepartments>();
builder.Services.AddScoped<IBLWorkers, BLWorkers>();

// DB stuff
builder.Services.AddDbContext<MainContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"))
);
//TODO: dev only?? https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#add-the-database-exception-filter
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHttpContextAccessor();

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
    app.UseDeveloperExceptionPage();
    app.UseCors(AllowAllCors);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
    //app.UseBrowserLink();
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

// as soon as the applications starts,
// 1. create the DB and apply migrations (if not already set up). (https://code-maze.com/migrations-and-seed-data-efcore/#setupinitialmigration; inspiration: https://stackoverflow.com/a/42356110)
// 2. initialize the DB with seed data (if not already seeded).
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var mainContext = services.GetRequiredService<MainContext>();

    mainContext.Database.Migrate();
    mainContext.Initialize();
}

app.Run();