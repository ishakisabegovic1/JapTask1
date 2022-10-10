namespace Api.Services.Email
{
  public interface IEmailService
  {
    Task<string> SendPlainTextEmail(string toEmail, string username, string password);
  }
}
