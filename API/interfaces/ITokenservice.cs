using API.DTOs;
using API.Entities;

namespace API.interfaces;

public interface ITokenservice{
    string CreateToken(UserData usr);
}