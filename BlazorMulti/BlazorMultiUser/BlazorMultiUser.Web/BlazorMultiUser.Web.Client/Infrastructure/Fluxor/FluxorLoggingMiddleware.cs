using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Fluxor;

namespace BlazorMultiUser.Web.Client.Infrastructure.Fluxor;

public class FluxorLoggingMiddleware(ILogger<FluxorLoggingMiddleware> logger) : Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        logger.LogDebug(nameof(InitializeAsync));
        return Task.CompletedTask;
    }

    public override void AfterInitializeAllMiddlewares()
    {
        logger.LogDebug(nameof(AfterInitializeAllMiddlewares));
    }

    public override bool MayDispatchAction(object action)
    {
        logger.LogDebug(nameof(MayDispatchAction) + ObjectInfo(action));
        return true;
    }

    public override void BeforeDispatch(object action)
    {
        logger.LogDebug(nameof(BeforeDispatch) + ObjectInfo(action));
    }

    public override void AfterDispatch(object action)
    {
        logger.LogDebug(nameof(AfterDispatch) + ObjectInfo(action));
    }

    private string ObjectInfo(object obj)
    {
        return ": " + obj.GetType().Name + " " + JsonSerializer.Serialize(obj);
    }
}