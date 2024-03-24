using BlazorMultiUser.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Infrastructure;

public class ServerValidationProblems(IDictionary<string, string[]> errors)
    : ValidationProblemDetails(errors), IServerValidationProblems;