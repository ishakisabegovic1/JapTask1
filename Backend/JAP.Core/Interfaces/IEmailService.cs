namespace JAP.Core
{
  public interface IEmailService
  {
    Task<string> SendPlainTextEmail(string toEmail, string username, string password);
    Task<string> SendSelectionReportEmail(AdminReportDto req);
  }
}
