using System.ComponentModel.DataAnnotations;
namespace API.DTOs;
public class RegisterDTO{
    [Required]
    [MaxLength(100)]
    public string username{get;set;}
    [Required]
    [MaxLength(20)]
    public string password { get; set; }
}