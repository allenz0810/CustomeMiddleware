using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace CustomeMiddleware
{
    public class SendEmail
    {
        public async Task SendEmailAsync(Email email)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("AZ", email.From));
            emailMessage.To.Add(new MailboxAddress("", email.To));
            emailMessage.Subject = email.Subject;
            emailMessage.Body = new TextPart("plain") { Text = email.Body };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = email.Domain;
                await client.ConnectAsync(email.Uri, email.port, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}