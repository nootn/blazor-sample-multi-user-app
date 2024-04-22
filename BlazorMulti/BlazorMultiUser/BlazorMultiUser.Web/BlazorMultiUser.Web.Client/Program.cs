using Blazored.LocalStorage;
using BlazorMultiUser.Web.Client;
using BlazorMultiUser.Web.Client.Infrastructure.Fluxor;
using BlazorMultiUser.Web.Client.Infrastructure.Ioc;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

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

builder.Services.AddFluentUIComponents();

builder.Services.UseSharedClientSide();

builder.Services.AddBlazoredLocalStorage();

//Fluxor
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(AssemblyMarkerClient).Assembly).AddMiddleware<FluxorLoggingMiddleware>();
#if DEBUG
    //options.UseReduxDevTools();
#endif
});

await builder.Build().RunAsync();