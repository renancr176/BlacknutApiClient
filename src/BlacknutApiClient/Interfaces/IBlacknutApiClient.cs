using System.Threading.Tasks;
using BlacknutApiClient.Models.Responses;
using Flurl.Http;

namespace BlacknutApiClient.Interfaces
{
    public interface IBlacknutApiClient
    {
        AuthenticationClient AuthenticationClient { get; }

        public Task<IFlurlRequest> GetBaseUrlAsync();

        public Task<ClientResponse<T>> GetErrorsAsync<T>(FlurlHttpException exception);
    }
}