using System.Threading.Tasks;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Responses;
using Flurl.Http;

namespace BlacknutApiClient.Interfaces
{
    public interface IBlacknutApiClient
    {
        AuthenticationClient AuthenticationClient { get; }

        public IFlurlRequest BaseUrl { get; }

        public Task<ClientResponse<T>> GetErrorsAsync<T>(FlurlHttpException exception);

        public Task<PaginationModel<T>> GetPaginationAsync<T>(IFlurlResponse response);
    }
}