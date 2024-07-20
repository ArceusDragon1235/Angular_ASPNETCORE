using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controller;


// [ApiController]
// [Route("api/[controller]")]
[Authorize]
public class UsersController : BaseApiController
{

    private readonly DataContext dataContext;
    public UsersController(DataContext Data):base(){

        this.dataContext = Data;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserData>>> Getdata()
    {
        var users = await dataContext.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserData>> GetDataasperID(int id)
    {
        
        return dataContext.Users.Find(id);
    }
}