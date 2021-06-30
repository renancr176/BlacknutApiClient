using System.Collections.Generic;

namespace BlacknutApiClient.Models.Responses
{
    public class SubscriptionsResponse : PaginationResponse
    {
        public IEnumerable<SubscriptionModel> Subscriptions { get; set; }
    }
}