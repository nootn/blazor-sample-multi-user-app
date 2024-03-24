namespace BlazorMultiUser.Web.Client.Features.Counter;

public static class ClientCounterState
{
    public const string LocalStorageKey = "ClientCounterState";

    public static int Count { get; set; }
}