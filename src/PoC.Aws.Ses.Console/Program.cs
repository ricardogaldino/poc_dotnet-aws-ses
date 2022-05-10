using Amazon.SimpleEmail;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PoC.Aws.Ses.Console.Dependency;
using PoC.Aws.Ses.Console.Settings;
using PoC.Aws.Ses.Console.Worker;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDependencyInjection();

        services.Configure<AwsOptions>(hostContext.Configuration.GetSection(AwsOptions.Aws));

        services.AddScoped<IAmazonSimpleEmailService>(sp => new AmazonSimpleEmailServiceClient(
            hostContext.Configuration["Aws:accessKey"],
            hostContext.Configuration["Aws:secretKey"],
            new AmazonSimpleEmailServiceConfig {ServiceURL = hostContext.Configuration["Aws:host"]}
        ));

        services.AddHostedService<MailWorker>();
    })
    .Build();

await host.RunAsync();