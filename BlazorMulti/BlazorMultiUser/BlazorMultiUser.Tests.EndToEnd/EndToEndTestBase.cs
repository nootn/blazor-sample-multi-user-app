using Microsoft.Playwright;

namespace BlazorMultiUser.Tests.EndToEnd;

public abstract class EndToEndTestBase
{
    private const string BaseUrl = "https://localhost:7295";
    private const bool Headless = false;

    protected async Task<IPage> CreateNewInNewBrowser()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        { Headless = Headless });
        return await browser.NewPageAsync();
    }

    protected string GetUrl(string relativeUrl)
    {
        var extraSlash = relativeUrl.StartsWith("/") ? "" : "/";
        return $"{BaseUrl}{extraSlash}{relativeUrl}";
    }
}