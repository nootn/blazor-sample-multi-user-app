using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Shared.Features.Counter;

public interface ICounterWriterService : IServiceCommon
{
    Task<Result<UserCountDto>> UpdateCounterForCurrentUser(UpdateCountRequest request);
}