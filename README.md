# Envato-API
https://build.envato.com/api/

A C# .NET Core wrapper for the Envato API. Work in progress.

## Examples:

```csharp
    protected readonly string clientId = "[YOUR-CLIENT-ID]";
    protected readonly string clientSecret = "[YOUR-CLIENT-SECRET]";

    // To get the code you need to authorize Envato by going to this link:
    // https://api.envato.com/authorization?response_type=code&client_id=[CLIENT ID]&redirect_uri=[REDIRECT URI]
    // Note: The "redirect_uri" needs to be the one you specified when you created your app on Envato
    // After going to the URL, you'll be redirected to your URL. Use the "code" value in the URL here.
    protected readonly string code = "[YOUR-ACCESS-CODE]";

    var authApi = new ApiRequest(clientId, clientSecret);
    var tokenResult = await authApi.AuthorizationRequest.GetAccessToken(code, clientId, clientSecret);

    var searchApi = new ApiRequest(clientId, clientSecret, tokenResult.AccessToken);
    var result = await searchApi.SearchRequest.Item("store", "codecanyon.net");
```
