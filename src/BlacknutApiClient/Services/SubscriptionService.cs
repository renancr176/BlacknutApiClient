using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;
using Flurl.Http;

namespace BlacknutApiClient.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IBlacknutApiClient _client;

        public SubscriptionService(IBlacknutApiClient client)
        {
            _client = client;
        }

        #region Privates

        private async Task<ClientResponse<SubscriptionResponse>> UpdateAsync(object data)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/update")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionResponse>> SuspendAsync(object data)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/suspend")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionResponse>> ReactivateAsync(object data)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/reactivate")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionResponse>> CancelAsync(object data)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/cancel")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionResponse>> AttachAsync(object data)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/attach")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        #endregion

        public async Task<ClientResponse<SubscriptionResponse>> CreateAsync(SubscriptionCreateRequest request)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription")
                    .PostJsonAsync(request);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<SubscriptionResponse>> GetByIdAsync(string id)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        #region Update product

        public async Task<ClientResponse<SubscriptionResponse>> UpdateByIdAsync(string id, UpdateProductRequest request)
        {
            var response = new ClientResponse<SubscriptionResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .PutJsonAsync(request);

                response.Data = await result.GetJsonAsync<SubscriptionResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<SubscriptionResponse>> UpdateByPartnerIdAsync(string partnerID, UpdateProductRequest request)
        {
            return await UpdateAsync(new {partnerID, request.NewProductId, request.OldProductId });
        }

        public async Task<ClientResponse<SubscriptionResponse>> UpdateByRedemptionCodeAsync(string redemptionCode, UpdateProductRequest request)
        {
            return await UpdateAsync(new { redemptionCode, request.NewProductId, request.OldProductId });
        }

        #endregion

        #region Suspend
        
        public async Task<ClientResponse<SubscriptionResponse>> SuspendByIdAsync(string id)
        {
            return await SuspendAsync(new { uuid = id });
        }

        public async Task<ClientResponse<SubscriptionResponse>> SuspendByPartnerIdAsync(string partnerID)
        {
            return await SuspendAsync(new { partnerID });
        }

        public async Task<ClientResponse<SubscriptionResponse>> SuspendByRedemptionCodeAsync(string redemptionCode)
        {
            return await SuspendAsync(new { redemptionCode });
        }

        #endregion

        #region Reactive

        public async Task<ClientResponse<SubscriptionResponse>> ReactivateByIdAsync(string id)
        {
            return await ReactivateAsync(new { uuid = id });
        }

        public async Task<ClientResponse<SubscriptionResponse>> ReactivateByPartnerIdAsync(string partnerID)
        {
            return await ReactivateAsync(new { partnerID });
        }

        public async Task<ClientResponse<SubscriptionResponse>> ReactivateByRedemptionCodeAsync(string redemptionCode)
        {
            return await ReactivateAsync(new { redemptionCode });
        }

        #endregion

        #region Cancel

        public async Task<ClientResponse<SubscriptionResponse>> CancelByIdAsync(string id, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { uuid = id, request.EndDate });
        }

        public async Task<ClientResponse<SubscriptionResponse>> CancelByPartnerIdAsync(string partnerID, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { partnerID, request.EndDate });
        }

        public async Task<ClientResponse<SubscriptionResponse>> CancelByRedemptionCodeAsync(string redemptionCode, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { redemptionCode, request.EndDate });
        }

        #endregion
    }
}