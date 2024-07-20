using System.ComponentModel.DataAnnotations;
namespace API.DTOs;
public class LoginDTO{

    [MaxLength(100)]
     public required string username{get;set;}
     [MaxLength(20)]
     public required string password{get;set;}
}
