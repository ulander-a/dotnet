using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

HttpClient client = new HttpClient();

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var clientId = "fc74a3d3-a1a6-427c-83b3-f8fa17310ea6";
var clientSecret = config["ClientSecret"];
var scopes = new[] {"api://e4905b25-7d3f-4cf2-98bc-f751ba30c308/.default"};
// var tenantId = "";     //Use in workforce tenant configuration
var tenantName = "loutenant"; //Use in external tenant configuration
var authority = $"https://{tenantName}.ciamlogin.com/"; // Use "https://{tenantName}.ciamlogin.com" for external tenant configuration 

var app = ConfidentialClientApplicationBuilder
    .Create(clientId)
    .WithAuthority(authority)
    .WithClientSecret(clientSecret)
    .Build();

var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
Console.WriteLine($"Access Token: [REDACTED]");

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
var response = await client.GetAsync("http://localhost:5055/api/todolist");
var content = await response.Content.ReadAsStringAsync();

Console.WriteLine("Your response is: " + response.StatusCode);
Console.WriteLine(content);