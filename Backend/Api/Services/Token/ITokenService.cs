using Api.Entities;

namespace Api.Services.Token
{
  public interface ITokenService
  {
    string CreateToken(User user);
  }
}
