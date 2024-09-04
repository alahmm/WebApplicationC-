using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)//ctor + tab zwei mal for constructor
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }
        public Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
