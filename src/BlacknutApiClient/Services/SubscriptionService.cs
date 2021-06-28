using System;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
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

        private async Task<ClientResponse<SubscriptionModel>> UpdateAsync(object data)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/update")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionModel>> SuspendAsync(object data)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/suspend")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionModel>> ReactivateAsync(object data)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/reactivate")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionModel>> CancelAsync(object data)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/cancel")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponse<SubscriptionModel>> AttachAsync(object data)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription/attach")
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        #endregion

        public async Task<ClientResponse<SubscriptionModel>> CreateAsync(SubscriptionCreateRequest request)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/subscription")
                    .PostJsonAsync(request);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<SubscriptionModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        #region Update product

        public async Task<ClientResponse<SubscriptionModel>> UpdateByIdAsync(Guid id, UpdateProductRequest request)
        {
            var response = new ClientResponse<SubscriptionModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .PutJsonAsync(request);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<SubscriptionModel>> UpdateByPartnerIdAsync(Guid partnerID, UpdateProductRequest request)
        {
            return await UpdateAsync(new {partnerID, request.NewProductId, request.OldProductId });
        }

        public async Task<ClientResponse<SubscriptionModel>> UpdateByRedemptionCodeAsync(string redemptionCode, UpdateProductRequest request)
        {
            return await UpdateAsync(new { redemptionCode, request.NewProductId, request.OldProductId });
        }

        #endregion

        #region Suspend
        
        public async Task<ClientResponse<SubscriptionModel>> SuspendByIdAsync(Guid id)
        {
            return await SuspendAsync(new { uuid = id });
        }

        public async Task<ClientResponse<SubscriptionModel>> SuspendByPartnerIdAsync(Guid partnerID)
        {
            return await SuspendAsync(new { partnerID });
        }

        public async Task<ClientResponse<SubscriptionModel>> SuspendByRedemptionCodeAsync(string redemptionCode)
        {
            return await SuspendAsync(new { redemptionCode });
        }

        #endregion

        #region Reactive

        public async Task<ClientResponse<SubscriptionModel>> ReactivateByIdAsync(Guid id)
        {
            return await ReactivateAsync(new { uuid = id });
        }

        public async Task<ClientResponse<SubscriptionModel>> ReactivateByPartnerIdAsync(Guid partnerID)
        {
            return await ReactivateAsync(new { partnerID });
        }

        public async Task<ClientResponse<SubscriptionModel>> ReactivateByRedemptionCodeAsync(string redemptionCode)
        {
            return await ReactivateAsync(new { redemptionCode });
        }

        #endregion

        #region Cancel

        public async Task<ClientResponse<SubscriptionModel>> CancelByIdAsync(Guid id, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { uuid = id, request.EndDate });
        }

        public async Task<ClientResponse<SubscriptionModel>> CancelByPartnerIdAsync(Guid partnerID, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { partnerID, request.EndDate });
        }

        public async Task<ClientResponse<SubscriptionModel>> CancelByRedemptionCodeAsync(string redemptionCode, SubscriptionCancelRequest request)
        {
            return await CancelAsync(new { redemptionCode, request.EndDate });
        }

        #endregion

        #region Attach
        
        public async Task<ClientResponse<SubscriptionModel>> AttachByIdAsync(Guid id, SubscriptionAttachRequest request)
        {
            return await AttachAsync(new { uuid = id, request.UserId });
        }

        public async Task<ClientResponse<SubscriptionModel>> AttachByPartnerIdAsync(Guid partnerID, SubscriptionAttachRequest request)
        {
            return await AttachAsync(new { partnerID, request.UserId });
        }

        public async Task<ClientResponse<SubscriptionModel>> AttachByRedemptionCodeAsync(string redemptionCode, SubscriptionAttachRequest request)
        {
            return await AttachAsync(new { redemptionCode, request.UserId });
        }

        #endregion
    }
}