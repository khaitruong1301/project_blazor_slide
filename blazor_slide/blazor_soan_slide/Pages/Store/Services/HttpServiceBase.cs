using System.Net.Http;

public class HttpServiceBase
{
    public HttpClient Client { get; }

    public HttpServiceBase(HttpClient client)
    {
        Client = client;
    }
}
