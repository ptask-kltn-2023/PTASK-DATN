using System.Net;

namespace PTASK.Extensions
{
    public static class HttpClientExtensions
    {
        public static IHttpClientBuilder AddCustomHttpClient(this IServiceCollection services, string name, string baseAddress)
        {
            return services.AddHttpClient(name, c =>
            {
                c.BaseAddress = new Uri(baseAddress);
            });
        }
    }
}
