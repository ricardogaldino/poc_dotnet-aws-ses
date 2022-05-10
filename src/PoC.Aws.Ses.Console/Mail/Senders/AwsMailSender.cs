using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using PoC.Aws.Ses.Console.Interfaces;
using PoC.Aws.Ses.Console.Mail.Dtos;

namespace PoC.Aws.Ses.Console.Mail.Senders;

public class AwsMailSender : IMailSender
{
    private const string Charset = "UTF-8";

    private readonly IAmazonSimpleEmailService _awsMailService;

    public AwsMailSender(IAmazonSimpleEmailService awsMailService)
    {
        _awsMailService = awsMailService;
    }

    public async Task<string> Send(MailRequestDto mail)
    {
        var receiver = CreateReceiver(mail);
        var message = CreateMessage(mail);
        var request = CreateRequest(mail.From, receiver, message);
        var response = await _awsMailService.SendEmailAsync(request);

        return response.MessageId;
    }

    private static Destination CreateReceiver(MailRequestDto mail)
    {
        var receiver = new Destination
        {
            ToAddresses = mail.To,
            CcAddresses = mail.Cc,
            BccAddresses = mail.Bcc
        };

        return receiver;
    }

    private static Message CreateMessage(MailRequestDto mail)
    {
        var message = new Message
        {
            Subject = new Content
            {
                Charset = Charset,
                Data = mail.Subject
            },
            Body = new Body
            {
                Html = new Content
                {
                    Charset = Charset,
                    Data = mail.Body
                }
            }
        };

        return message;
    }

    private SendEmailRequest CreateRequest(string sender, Destination receiver, Message message)
    {
        var request = new SendEmailRequest
        {
            Message = message,
            Source = sender,
            Destination = receiver
        };

        return request;
    }
}