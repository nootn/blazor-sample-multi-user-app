using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Shared.Features.Counter;

public interface ICounterReaderService : IServiceCommon
{
    Task<Result<UserCountDto>> GetCounterForCurrentUser();
}