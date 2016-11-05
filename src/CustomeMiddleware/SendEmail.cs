using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

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
            // create an image attachment for the file located at path
            //var attachment = new MimePart("image", "png")
            //{
            //    ContentObject = new ContentObject(File.OpenRead(path), ContentEncoding.Default),
            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            //    ContentTransferEncoding = ContentEncoding.Base64,
            //    FileName = Path.GetFileName(path)
            //};

            var alternative = new Multipart("alternative");
            alternative.Add(html);

            // now create the multipart/mixed container to hold the message text and the
            // image attachment
            var multipart = new Multipart("mixed");
            multipart.Add(alternative);
            //multipart.Add(attachment);
            message.Body = multipart;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(email.From, email.Password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}