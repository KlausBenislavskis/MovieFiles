using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MovieFiles.Api.Client;
using MovieFiles.Ui.Http.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        builder.Configuration.Bind("AzureAd", options);
        options.Events ??= new OpenIdConnectEvents();
        options.Events.OnRedirectToIdentityProvider = async context =>
        {
            Console.WriteLine(context.Request.Host);
            context.ProtocolMessage.RedirectUri = $"https://{context.Request.Host}/signin-oidc";
            await Task.FromResult(0);

        };
        // Add these lines to set SameSite and Secure properties for OpenID Connect cookies
        options.NonceCookie.SameSite = SameSiteMode.None;
        options.NonceCookie.SecurePolicy = CookieSecurePolicy.Always;

        options.CorrelationCookie.SameSite = SameSiteMode.None;
        options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;

    });
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization();



builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUserResolver, UserResolver>();

builder.Services.AddMovieFilesClient(builder.Configuration["MovieFilesAPI"], Environment.GetEnvironmentVariable("MOVIE_FUNCTION_KEY"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
//app.UseExceptionHandler("/Error");
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
