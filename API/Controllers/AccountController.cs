using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using System.Security.Cryptography.X509Certificates;
using API.interfaces;
using API.Services;

namespace API.Controller;
public class AccountController : BaseApiController{
    private readonly DataContext Data1;
    private readonly ITokenservice itks;
    public AccountController(DataContext Data1, ITokenservice itks):base(){
      this.Data1 = Data1;
      this.itks = itks;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> login(LoginDTO LDTO){
        var user = await Data1.Users.FirstOrDefaultAsync(x=>x.UserName.ToLower() == LDTO.username.ToLower());
        if(user == null) return Unauthorized("User not Found");
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedhash  = hmac.ComputeHash(Encoding.UTF8.GetBytes(LDTO.password));
        for(int i=0;i<user.PasswordHash.Length;i++){
            if(user.PasswordHash[i] != computedhash[i]) return Unauthorized("password is incorrect");
        }
        return new TokenDTO{
            UserName = LDTO.username,
            Token = itks.CreateToken(user)
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult<TokenDTO>> Register(RegisterDTO regDTO){
        var hscp = new HMACSHA512();
        if(await userExists(regDTO.username)) return BadRequest("Username has taken");
        var user = new UserData{
            UserName = regDTO.username.ToLower(),
            PasswordHash = hscp.ComputeHash(Encoding.UTF8.GetBytes(regDTO.password)),
            PasswordSalt = hscp.Key
        };
        Data1.Users.Add(user);
        await Data1.SaveChangesAsync();
        return new TokenDTO{
            UserName = regDTO.username,
            Token = itks.CreateToken(user)
        };
    }
    private async Task<bool> userExists(string username){
        return await Data1.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
    }
