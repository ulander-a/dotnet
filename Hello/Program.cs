using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
IHostEnvironment env = builder.Environment;

Console.WriteLine("Hello! Let's look at some environmental variables.");
Console.WriteLine($"Environment: {env.EnvironmentName}");

if (env.IsDevelopment())
    Console.WriteLine("Dev mode");
else if (env.IsStaging())
    Console.WriteLine("Are we in Staging? Yes!");
else
    Console.WriteLine("Production (or something custom)");
