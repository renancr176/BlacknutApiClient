using System.Threading.Tasks;
using BlacknutApiClient.Models;
using Flurl.Http;

namespace BlacknutApiClient.Interfaces
{
    public interface IBlacknutApiClient
    {
        AuthenticationClient AuthenticationClient { get; }

        public IFlurlRequest BaseUrl { get; }

        public Task<ClientResponseModel<T>> GetErrorsAsync<T>(FlurlHttpException exception);
    }
}