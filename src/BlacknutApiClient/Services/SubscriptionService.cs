using System;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
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

        private async Task<ClientResponseModel<SubscriptionModel>> UpdateAsync(object data)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription/update")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponseModel<SubscriptionModel>> SuspendAsync(object data)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription/suspend")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponseModel<SubscriptionModel>> ReactivateAsync(object data)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription/reactivate")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponseModel<SubscriptionModel>> CancelAsync(object data)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription/cancel")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PutJsonAsync(data);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        private async Task<ClientResponseModel<SubscriptionModel>> AttachAsync(object data)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription/attach")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
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

        public async Task<ClientResponseModel<SubscriptionModel>> CreateAsync(SubscriptionCreationModel model)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/subscription")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PostJsonAsync(model);

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<SubscriptionModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<SubscriptionModel>> UpdateByIdAsync(Guid id, Guid oldProductID, Guid newProductID)
        {
            var response = new ClientResponseModel<SubscriptionModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/subscription/{id}")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PutJsonAsync(new { oldProductID, newProductID });

                response.Data = await result.GetJsonAsync<SubscriptionModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<SubscriptionModel>> UpdateByPartnerIdAsync(Guid partnerID, Guid oldProductID, Guid newProductID)
        {
            return await UpdateAsync(new {partnerID, oldProductID, newProductID});
        }

        public async Task<ClientResponseModel<SubscriptionModel>> UpdateByRedemptionCodeAsync(string redemptionCode, Guid oldProductID, Guid newProductID)
        {
            return await UpdateAsync(new { redemptionCode, oldProductID, newProductID });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> SuspendByIdAsync(Guid id)
        {
            return await SuspendAsync(new { uuid = id });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> SuspendByPartnerIdAsync(Guid partnerID)
        {
            return await SuspendAsync(new { partnerID });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> SuspendByRedemptionCodeAsync(string redemptionCode)
        {
            return await SuspendAsync(new { redemptionCode });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> ReactivateByIdAsync(Guid id)
        {
            return await ReactivateAsync(new { uuid = id });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> ReactivateByPartnerIdAsync(Guid partnerID)
        {
            return await ReactivateAsync(new { partnerID });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> ReactivateByRedemptionCodeAsync(string redemptionCode)
        {
            return await ReactivateAsync(new { redemptionCode });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> CancelByIdAsync(Guid id, DateTime? endDate = null)
        {
            return await CancelAsync(new { uuid = id, endDate });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> CancelByPartnerIdAsync(Guid partnerID, DateTime? endDate = null)
        {
            return await CancelAsync(new { partnerID, endDate });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> CancelByRedemptionCodeAsync(string redemptionCode, DateTime? endDate = null)
        {
            return await CancelAsync(new { redemptionCode, endDate });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> AttachByIdAsync(Guid id, Guid userId)
        {
            return await AttachAsync(new { uuid = id, userId });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> AttachByPartnerIdAsync(Guid partnerID, Guid userId)
        {
            return await AttachAsync(new { partnerID, userId });
        }

        public async Task<ClientResponseModel<SubscriptionModel>> AttachByRedemptionCodeAsync(string redemptionCode, Guid userId)
        {
            return await AttachAsync(new { redemptionCode, userId });
        }
    }
}