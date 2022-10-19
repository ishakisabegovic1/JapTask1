
namespace JAP.Core.Interfaces
{
  public interface IAuthService
  {
    public Task<dynamic> Login(LoginDto login);
  }
}
