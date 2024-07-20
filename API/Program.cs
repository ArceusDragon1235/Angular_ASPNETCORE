using API.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationserviceExtension(builder.Configuration);
builder.Services.Addidentityservice(builder.Configuration);
var app = builder.Build();

app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200/","https://localhost:4200/"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// app.UseStaticFiles(new StaticFileOptions
//     {
//         FileProvider = new PhysicalFileProvider(
//             Path.Combine(app.Environment.ContentRootPath, "MyStaticFiles")), // MyStaticFiles is new folder
//         RequestPath = "/StaticFiles"  // this is requested path by client
//     });
