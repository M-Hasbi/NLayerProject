using System.Net.Http;

namespace NLayerProject.Web.Api_Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient )
        {
          _httpClient = httpClient;
        }
    }
}
