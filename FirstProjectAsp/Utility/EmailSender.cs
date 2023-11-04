using Microsoft.AspNetCore.Identity.UI.Services;

namespace FirstProjectAsp.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //email gönderme işlemleri
           return Task.CompletedTask;
        }
    }
}
