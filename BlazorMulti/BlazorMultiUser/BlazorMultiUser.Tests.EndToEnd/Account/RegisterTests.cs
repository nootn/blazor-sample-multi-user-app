using BlazorMultiUser.Shared;
using BlazorMultiUser.Web.Components.Account.Pages;
using FluentAssertions;
using Microsoft.Playwright;

namespace BlazorMultiUser.Tests.EndToEnd.Account;

public class RegisterTests : EndToEndTestBase
{
    

    [Fact]
    public async Task RegisterPageShowsCorrectValidationErrors()
    {
        var page = await CreateNewInNewBrowser();

        await page.GotoAsync(GetUrl(Navigation.Url.AccountRegister));

        await ClickRegisterButton(page);

        (await GetValidationSummaryContent(page)).Should().Contain(Register.PageObject.Email.ValidationRequiredMessage);
        (await GetEmailInlineValidationContent(page)).Should().Contain(Register.PageObject.Email.ValidationRequiredMessage);
    }

    
    private static async Task ClickRegisterButton(IPage page)
    {
        await page.ClickAsync($"[data-field={Register.PageObject.RegisterSubmitButtonDataField}]");
    }

    private static async Task<string?> GetValidationSummaryContent(IPage page)
    {
        var validationSummary = await page.TextContentAsync($"[data-field={Register.PageObject.ValidationSummaryDataField}]");
        return validationSummary;
    }

    private static async Task<string?> GetEmailInlineValidationContent(IPage page)
    {
        var validationSummary = await page.TextContentAsync($"[data-field={Register.PageObject.Email.InlineValidationDataField}]");
        return validationSummary;
    }
}