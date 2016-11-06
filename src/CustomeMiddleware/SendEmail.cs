using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using System.IO;

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

            //using (var client = new SmtpClient())
            //{
            //    client.LocalDomain = email.Domain;
            //    await client.ConnectAsync(email.Uri, email.port, SecureSocketOptions.None).ConfigureAwait(false);
            //    await client.SendAsync(emailMessage).ConfigureAwait(false);
            //    await client.DisconnectAsync(true).ConfigureAwait(false);
            //}
        }

        public async Task SendEmailWithGmailAccountAsync(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromYou", email.From));
            message.To.Add(new MailboxAddress("ToThem", email.To));
            message.Subject = string.Format("Email from custom middleware.");

            var html = new TextPart("html")
            {
                Text = @"Sending Email from custom middleware."
            };

            var alternative = new Multipart("alternative");
            alternative.Add(html);

            var multipart = new Multipart("mixed");
            multipart.Add(new MimePart()
            {
                ContentObject = new ContentObject(File.OpenRead(email.Attachment), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(email.Attachment)
            });
            //multipart.Add(attachment);
            message.Body = multipart;

            using (var client = new SmtpClient())
            {
                client.Connect(email.Server, email.Port, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(email.From, email.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}