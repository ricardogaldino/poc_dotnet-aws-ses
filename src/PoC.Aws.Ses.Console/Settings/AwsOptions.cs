namespace PoC.Aws.Ses.Console.Settings;

public class AwsOptions
{
    public const string Aws = "Aws";
    public string Host { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string AccessKey { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
}