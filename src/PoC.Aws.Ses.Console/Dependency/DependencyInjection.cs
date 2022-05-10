using Microsoft.Extensions.DependencyInjection;
using PoC.Aws.Ses.Console.Interfaces;
using PoC.Aws.Ses.Console.Mail.Senders;

namespace PoC.Aws.Ses.Console.Dependency;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IMailSender, AwsMailSender>();
    }
}