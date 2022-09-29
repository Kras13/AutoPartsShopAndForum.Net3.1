namespace SMTH.MailSender.Interfaces
{
    public interface IMailSender
    {
        bool SendMail(string server, string sender, string receiver);
    }
}