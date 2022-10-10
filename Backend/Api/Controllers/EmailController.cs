using Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Api.Controllers
{
  public class EmailController : BaseApiController
  {
    private readonly ISendGridClient _sendGridClient;
    private readonly IConfiguration _config;

    public EmailController(ISendGridClient sendGridClient, IConfiguration config)
    {
      _sendGridClient = sendGridClient;
      _config = config;
    }
    [HttpGet]
    [Route("send-text-mail")]
    public async Task<ActionResult> SendPlainTextEmail(string toEmail, string username, string password)
    {
      string fromEmail = _config.GetSection("SendGridEmailSettings")
        .GetValue<string>("FromEmail");
      string fromName = _config.GetSection("SendGridEmailSettings")
        .GetValue<string>("FromName");

      var msg = new SendGridMessage()
      {
        From = new EmailAddress(fromEmail, fromName),
        Subject = "Plain Text Email",
        PlainTextContent = "Hello welcome!"
      };

      msg.AddTo(toEmail);

      var response = await _sendGridClient.SendEmailAsync(msg);

      string message = response.IsSuccessStatusCode ? "Email sent" : "Email sending failed";
      return Ok(message);

    }
  }
}
