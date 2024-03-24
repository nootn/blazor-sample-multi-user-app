using Fluxor;

namespace BlazorMultiUser.Web.Client.Features.Counter.State;

[FeatureState]
public class CounterGlobalState(
    bool isLoading,
    bool isServerSideRender,
    int appInstanceCounter,
    int localStorageCounter,
    int? databaseCounter)
{
    private CounterGlobalState() : this(true, true, 0, 0, null)
    {
    }

    public bool IsLoading { get; } = isLoading;
    public bool IsServerSideRender { get; } = isServerSideRender;
    public int AppInstanceCounter { get; } = appInstanceCounter;
    public int LocalStorageCounter { get; } = localStorageCounter;
    public int? DatabaseCounter { get; } = databaseCounter;
}