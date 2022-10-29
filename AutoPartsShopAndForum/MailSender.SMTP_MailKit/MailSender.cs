using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace MailSender.SMTP_MailKit
{
    public class MailSender
    {
        public static string SendEmail(string body)
        {
            var email = new MimeMessage();
            string result = "";

            email.From.Add(MailboxAddress.Parse("daren16@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("daren16@ethereal.email"));
            email.Subject = "Test Email";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            {
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("daren16@ethereal.email", "44EpCVGjg2apypzRPV");
                result = smtp.Send(email);
                smtp.Disconnect(true);
            }

            return result;
        }
    }
}
