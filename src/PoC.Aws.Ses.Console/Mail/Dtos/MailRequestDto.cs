namespace PoC.Aws.Ses.Console.Mail.Dtos;

public class MailRequestDto
{
    public string From { get; set; } = null!;
    public List<string> To { get; set; } = null!;
    public List<string> Cc { get; set; } = default!;
    public List<string> Bcc { get; set; } = default!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}