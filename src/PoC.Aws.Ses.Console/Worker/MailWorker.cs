using Microsoft.Extensions.Hosting;
using PoC.Aws.Ses.Console.Interfaces;
using PoC.Aws.Ses.Console.Mail.Dtos;

namespace PoC.Aws.Ses.Console.Worker;

public class MailWorker : BackgroundService
{
    private readonly IMailSender _mailSender;

    public MailWorker(IMailSender mailSender)
    {
        _mailSender = mailSender;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var mailRequest = new MailRequestDto
            {
                From = "sender@email.com",
                To = new List<string> {"receiver@email.com"},
                Subject = "Mussum Ipsum",
                Body = @"Cacilds vidis litro abertis. 
                         Suco de cevadiss, é um leite divinis, qui tem lupuliz, matis, aguis e fermentis.
                         Quem num gosta di mé, boa gentis num é.
                         Quem num gosta di mim que vai caçá sua turmis!
                         Suco de cevadiss deixa as pessoas mais interessantis."
            };

            var response = await _mailSender.Send(mailRequest);

            System.Console.WriteLine("**************************************************");
            System.Console.WriteLine("SUCCESS!");
            System.Console.WriteLine("**************************************************");
            System.Console.WriteLine(@$"Message ID in AWS SES: {response}");
            System.Console.WriteLine("**************************************************");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("**************************************************");
            System.Console.WriteLine("FAILED!");
            System.Console.WriteLine("**************************************************");
            System.Console.WriteLine(@$"Error message: {ex.Message}");
            System.Console.WriteLine("**************************************************");
        }
    }
}