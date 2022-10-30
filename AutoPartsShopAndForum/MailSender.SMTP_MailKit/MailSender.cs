namespace MailSender.SMTP_MailKit
{
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
    using MimeKit.Text;

    public class MailSender
    {
        public static string SendEmail(string body)
        {
            var email = new MimeMessage();
            string result = "";

            email.From.Add(MailboxAddress.Parse("maryjane.huels14@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("maryjane.huels14@ethereal.email"));
            email.Subject = "Test Email";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            {
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("maryjane.huels14@ethereal.email", "JyBEEfaVkJtRBu5DeA");
                result = smtp.Send(email);
                smtp.Disconnect(true);
            }

            return result;
        }
    }
}
