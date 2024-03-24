using System.Net.Http.Json;
using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Features.Counter;

public class CounterWriterServiceClient(HttpClient httpClient) : ServiceCommonBase, ICounterWriterService
{
    public async Task<Result<UserCountDto>> UpdateCounterForCurrentUser(UpdateCountRequest request)
    {
        var httpRes = await httpClient.PostAsJsonAsync(ApiEndpoints.UpdateCounterForCurrentUser, request);
        var res = await httpRes.Content.ReadFromJsonAsync<UserCountDto>();
        return Result<UserCountDto>.CreateSuccessResult(res ?? new UserCountDto(0));
    }
}