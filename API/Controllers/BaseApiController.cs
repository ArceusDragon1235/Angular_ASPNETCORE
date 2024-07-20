using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controller;


[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    public BaseApiController()
    {

    }
}