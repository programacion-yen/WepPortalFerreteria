namespace PortalFerreteria.Shared.Services
{
    public class ClientFactory
    {
        public HttpClient HttpClientInstance { get; set; }
        public ClientFactory(string Uri)
        {
            HttpClientInstance = new HttpClient
            {
                BaseAddress = new Uri(Uri)
            };
        }
    }
}
