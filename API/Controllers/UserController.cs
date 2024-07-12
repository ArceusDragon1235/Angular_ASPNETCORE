using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controller;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext dataContext;
    public UserController(DataContext Data)
    {
        this.dataContext = Data;
    }

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