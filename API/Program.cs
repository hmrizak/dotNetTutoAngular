using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
builder.Services.AddCors(options => options.AddPolicy("AllowAccess_TO_API",
                policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAccess_TO_API");
//app.UseCors(builder => builder
//    .AllowAnyOrigin()
//    .AllowAnyHeader()
 //   .AllowAnyMethod());
    //.WithOrigins("http://localhost:4200")

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
