using API;
using API.Data;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
namespace API.Extensions;
public static class ApplicationserviceExtension
{
    public static IServiceCollection AddApplicationserviceExtension(this IServiceCollection sc, IConfiguration conf)
    {
        sc.AddControllers();
        sc.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(conf.GetConnectionString("DefaultConnection"));
        });
        sc.AddCors();
        sc.AddScoped<ITokenservice, TokenService>();
        return sc;
    }
}