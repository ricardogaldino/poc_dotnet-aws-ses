using PoC.Aws.Ses.Console.Mail.Dtos;

namespace PoC.Aws.Ses.Console.Interfaces;

public interface IMailSender
{
    Task<string> Send(MailRequestDto mail);
}