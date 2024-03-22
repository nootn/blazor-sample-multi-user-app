using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Client;
using BlazorMultiUser.Web.Client.Infrastructure;
using BlazorMultiUser.Web.Client.Infrastructure.Ioc;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

// Configure HttpClient to use the base address of the server project
builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

builder.Services.UseSharedClientSide();



await builder.Build().RunAsync();