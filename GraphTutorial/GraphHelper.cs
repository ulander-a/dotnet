using Azure.Core;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Me.SendMail;
using GraphTutorial;

class GraphHelper
{
    // Settings object
    private static Settings? settings;

    // User auth token credential
    private static DeviceCodeCredential? deviceCodeCredential;

    // Client configured with user authentication
    private static GraphServiceClient? userClient;

    public static void InitializeGraphForUserAuth(
        Settings settings,
        Func<DeviceCodeInfo, CancellationToken, Task> deviceCodePrompt)
    {
        GraphHelper.settings = settings;

        var options = new DeviceCodeCredentialOptions
        {
            ClientId = settings.ClientId,
            TenantId = settings.TenantId,
            DeviceCodeCallback = deviceCodePrompt,
        };

        deviceCodeCredential = new DeviceCodeCredential(options);

        userClient = new GraphServiceClient(deviceCodeCredential, settings.GraphUserScopes);
    }

    public static async Task<string> GetUserTokenAsync()
    {
        // Ensure credential isn't null
        if (deviceCodeCredential is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        // Ensure scopes isn't null
        if (settings?.GraphUserScopes is null)
            throw new ArgumentNullException("Argument 'scopes' cannot be null");

        // Request token with given scopes
        var context = new TokenRequestContext(settings.GraphUserScopes);
        var response = await deviceCodeCredential.GetTokenAsync(context);
        return response.Token;
    }

    public static Task<User?> GetUserAsync()
    {
        // Ensure client isn't null
        if (userClient is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        return userClient.Me.GetAsync((config) =>
        {
            // Only request specific properties
            config.QueryParameters.Select = ["displayName", "mail", "userPrincipalName"];
        });
    }

    public static Task<MessageCollectionResponse?> GetInboxAsync()
    {
        // Ensure client isn't null
        if (userClient is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        return userClient.Me
            .MailFolders["Inbox"] // Only messages from Inbox folder
            .Messages
            .GetAsync((config) =>
            {
                /* Only request specific properties */
                config.QueryParameters.Select = ["from", "isRead", "receivedDateTime", "subject"];
                /* Get at most 25 results */
                config.QueryParameters.Top = 25;
                /* Sort by received time, newest first */
                config.QueryParameters.Orderby = ["receivedDateTime DESC"];
            });
    }

    public static async Task SendMailAsync(string subject, string body, string recipient)
    {
        // Ensure client isn't null
        if (userClient is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        // Create a new message
        var message = new Message
        {
            Subject = subject,
            Body = new ItemBody
            {
                Content = body,
                ContentType = BodyType.Text,
            },
            ToRecipients =
            [
                new Recipient
            {
                EmailAddress = new EmailAddress
                {
                    Address = recipient,
                },
            },
        ],
        };

        // Send the message
        await userClient.Me
            .SendMail
            .PostAsync(new SendMailPostRequestBody
            {
                Message = message,
            });
    }

    public static Task<DirectoryObjectCollectionResponse?> GetMemberOfAsync()
    {
        // Ensure client isn't null
        if (userClient is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        return userClient.Me.MemberOf.GetAsync();
    }

        public static Task<DirectoryObjectCollectionResponse?> GetOwnedObjectsAsync()
    {
        // Ensure client isn't null
        if (userClient is null)
            throw new NullReferenceException("Graph has not been initialized for user auth");

        return userClient.Me.OwnedObjects.GetAsync();
    }
}