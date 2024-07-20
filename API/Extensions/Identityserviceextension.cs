using System.Text;
using API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace API.Extensions;
public static class Identityserviceextension
{
    public static IServiceCollection Addidentityservice(this IServiceCollection sc, IConfiguration conf)
    {
        sc.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
AddJwtBearer(
Options =>
{
    var Token = conf["TokenKey"] ?? throw new Exception("Invalid Token");
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
return sc;
    }
}