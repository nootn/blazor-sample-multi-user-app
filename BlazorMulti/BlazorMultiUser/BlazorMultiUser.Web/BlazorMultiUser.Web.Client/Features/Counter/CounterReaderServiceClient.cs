using System.Net.Http.Json;
using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Features.Counter;

public class CounterReaderServiceClient(HttpClient httpClient) : ServiceCommonBase, ICounterReaderService
{
    public async Task<Result<UserCountDto>> GetCounterForCurrentUser()
    {
        var res = await httpClient.GetFromJsonAsync<UserCountDto>(ApiEndpoints.GetAllGetCounterForCurrentUser) ?? new UserCountDto(0);
        return Result<UserCountDto>.CreateSuccessResult(res);
    }
}