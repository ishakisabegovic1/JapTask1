using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Api.Services.Email
{
  public class EmailService : IEmailService
  {
    private readonly ISendGridClient _sendGridClient;
    private readonly IConfiguration _config;

    public EmailService(ISendGridClient sendGridClient, IConfiguration config)
    {
      _sendGridClient = sendGridClient;
      _config = config;
    }

    public async Task<string> SendPlainTextEmail(string toEmail, string username, string password)
    {
      string fromEmail = _config.GetSection("SendGridEmailSettings")
        .GetValue<string>("FromEmail");
      string fromName = _config.GetSection("SendGridEmailSettings")
        .GetValue<string>("FromName");

      var msg = new SendGridMessage()
      {
        From = new EmailAddress(fromEmail, fromName),
        Subject = "Login credentials",
        PlainTextContent = $"Username: {username} \nPassword: {password}"
      };

      msg.AddTo(toEmail);

      var response = await _sendGridClient.SendEmailAsync(msg);

      string message = response.IsSuccessStatusCode ? "Email sent" : "Email sending failed";
      return message;

    }
  }
}
