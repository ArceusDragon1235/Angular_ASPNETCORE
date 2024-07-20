using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService:ITokenservice{
    private IConfiguration config{get;set;}
    public TokenService(IConfiguration config){
        this.config = config;
    }
    public string CreateToken(UserData user){
        var TokenKey = config["TokenKey"] ?? throw new Exception("Cannot Access Token Key from appsettings");
        if(TokenKey.Length < 64) throw new Exception("Token key should be longer");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
        var claims = new List<Claim>{
            new(ClaimTypes.NameIdentifier,user.UserName),
        };
        var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
        var Tokendesc = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = cred
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(Tokendesc);
        return tokenHandler.WriteToken(token);
    }
    //  public string CreateToken1(UserData usd){
    //     var token = config["Tokenkey"];
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));
    //     var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);
    //     var claims = new List<Claim>{
    //         new(ClaimTypes.NameIdentifier,usd.UserName)
    //     };
    //     var desc = new SecurityTokenDescriptor{
    //         Subject = new ClaimsIdentity(claims),
    //         Expires = DateAndTime.Now.AddHours(7),
    //         SigningCredentials = cred
    //     };
    //     var handler = new JwtSecurityTokenHandler();
    //     var token1 = handler.CreateToken(desc);
    //     return handler.WriteToken(token1);
    //  }
}