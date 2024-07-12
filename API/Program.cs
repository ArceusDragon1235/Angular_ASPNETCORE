using API.Data;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200/","https://localhost:4200/"));
app.MapControllers();
app.Run();

// app.UseStaticFiles(new StaticFileOptions
//     {
//         FileProvider = new PhysicalFileProvider(
//             Path.Combine(app.Environment.ContentRootPath, "MyStaticFiles")), // MyStaticFiles is new folder
//         RequestPath = "/StaticFiles"  // this is requested path by client
//     });
