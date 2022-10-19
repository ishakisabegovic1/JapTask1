namespace JAP.Core
{
  public interface IUserRepository
  {
    Task<List<JAP.Core.User>> GetUsers();
    Task<JAP.Core.User> GetUserById(int id);
  }
}
