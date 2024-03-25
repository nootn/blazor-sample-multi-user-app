using System.Net;
using System.Net.Sockets;
using BlazorMultiUser.Web;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlazorMultiUser.Tests.Integration;

public class WebAppFactory : WebApplicationFactory<AssemblyMarkerServerProgram>
{
    public static int GetAvailablePort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }
}