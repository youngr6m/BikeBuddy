using bikebuddy.app.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

// add an authentication service to enable OAUTH2 login via Strava
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "Strava";// CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOAuth("Strava", options =>
{
    options.ClientId                = builder.Configuration["Strava:ClientId"];
    options.ClientSecret            = builder.Configuration["Strava:ClientSecret"];
    options.CallbackPath            = new PathString("/signin-oidc");
    
    options.Scope.Add("activity:read_all,profile:read_all,read_all");
    
    options.AuthorizationEndpoint   = "https://www.strava.com/oauth/authorize";
    options.TokenEndpoint           = "https://www.strava.com/oauth/token";
    options.UserInformationEndpoint = "https://www.strava.com/api/v3/athlete";

    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
    
    options.SaveTokens = true;

    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            // log a message to the console when the user logs in
            Console.WriteLine($"User logged in - access token {context.AccessToken} ");

            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                        response.EnsureSuccessStatusCode();

                        var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
                        context.RunClaimActions(user);
        }
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


app.MapRazorComponents<App>()
     .AddInteractiveServerRenderMode();

app.Run();
