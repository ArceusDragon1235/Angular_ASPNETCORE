namespace API.Entities;

public class UserData{
    public int ID { get; set; }
    public required string UserName { get; set; }
    
    #nullable enable
    public required byte[]? PasswordHash { get; set; }
    public required byte[]? PasswordSalt { get; set; }
    #nullable disable
}