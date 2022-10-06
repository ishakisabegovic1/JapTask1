namespace Api.Repositories.User
{
  public interface IUserRepository
  {
    Task<List<Entities.User>> GetUsers();
    Task<Entities.User> GetUserById(int id);
  }
}
