using Blazored.LocalStorage;
using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;

// ReSharper disable UnusedMember.Global

namespace BlazorMultiUser.Web.Client.Features.Counter.State;

//NOTE: not working due to bug with pre v6: https://github.com/mrpmorris/Fluxor/pull/481

public static class CounterGlobalActions
{
    public class Initialize(CounterGlobalState state)
    {
        public CounterGlobalState State { get; } = state;
    }

    public record UpdateAppInstanceCounter(int AppInstanceCounter);

    public record UpdateLocalStorageCounter(int LocalStorageCounter);

    public record UpdateDatabaseCounter(int DatabaseCounter);

    public record UpdateAllCounters(
        int AppInstanceCounter, 
        int LocalStorageCounter, 
        int? DatabaseCounter);

    public record UpdateAllCountersComplete(
        bool IsServerSideRender,
        int AppInstanceCounter,
        int LocalStorageCounter,
        int? DatabaseCounter);


    [ReducerMethod]
    public static CounterGlobalState Reduce(CounterGlobalState state, Initialize action)
    {
        return new CounterGlobalState(true,
            state.IsServerSideRender,
            state.AppInstanceCounter,
            state.LocalStorageCounter,
            state.DatabaseCounter);
    }

    [ReducerMethod]
    public static CounterGlobalState Reduce(CounterGlobalState state,
        UpdateAllCountersComplete action)
    {
        return new CounterGlobalState(false,
            action.IsServerSideRender,
            action.AppInstanceCounter,
            action.LocalStorageCounter,
            action.DatabaseCounter);
    }


    public class Effects(
        IAppContextService appContextService,
        ILocalStorageService localStorageService,
        ICounterReaderService counterReaderService,
        AuthenticationStateProvider authenticationStateProvider)
    {
        [EffectMethod]
        public async Task Handle(Initialize action, IDispatcher dispatcher)
        {
            var appInstanceCounter = action.State.AppInstanceCounter;
            var localStorageCounter = await GetLocalStorageCounter(action.State.LocalStorageCounter);
            var databaseCounter = await GetDatabaseCounter(action.State.DatabaseCounter);

            dispatcher.Dispatch(new UpdateAllCountersComplete(appContextService.IsServerSideRender,
                appInstanceCounter,
                localStorageCounter,
                databaseCounter));
        }

        [EffectMethod]
        public async Task Handle(UpdateAllCounters action, IDispatcher dispatcher)
        {
            var appInstanceCounter = action.AppInstanceCounter;
            var localStorageCounter = await GetLocalStorageCounter(action.LocalStorageCounter);
            var databaseCounter = await GetDatabaseCounter(action.DatabaseCounter);

            dispatcher.Dispatch(new UpdateAllCountersComplete(appContextService.IsServerSideRender,
                appInstanceCounter,
                localStorageCounter,
                databaseCounter));
        }


        private async Task<int> GetLocalStorageCounter(int defaultValue)
        {
            var localStorageCounter = defaultValue;
            if (!appContextService.IsServerSideRender)
                localStorageCounter =
                    await localStorageService.GetItemAsync<int>(ClientCounterState.LocalStorageKey);
            return localStorageCounter;
        }
        
        private async Task<bool> SetLocalStorageCounter(int value)
        {
            if (!appContextService.IsServerSideRender)
            {
                await localStorageService.SetItemAsync(ClientCounterState.LocalStorageKey, value);
                return true;
            }
            return false;
        }

        private async Task<int?> GetDatabaseCounter(int? defaultValue)
        {
            var databaseCounter = defaultValue;
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity?.IsAuthenticated == true)
            {
                var res = await counterReaderService.GetCounterForCurrentUser();
                if (res is Result<UserCountDto>.Success success) databaseCounter = success.Value.Counter;
            }

            return databaseCounter;
        }
    }
}