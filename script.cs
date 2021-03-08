using Flurl.Http;
using Microsoft.Identity.Client;
using static System.Console;

string clientId = "66a34107-d88f-4575-ba34-9b0b63211e72";

var app = PublicClientApplicationBuilder.Create(clientId)
.WithRedirectUri("http://localhost")
.Build();

string[] scopes = new string[]
{
    "https://graph.microsoft.com/user.read"
};

var result = await app.AcquireTokenInteractive(scopes)
.ExecuteAsync();

//WriteLine(result.AccessToken);

string json = await "https://graph.microsoft.com/beta/me"
.WithOAuthBearerToken(result.AccessToken)
.GetStringAsync();

WriteLine(json);