namespace Northwind.API.Utlity
{
    using Polly;
    using Polly.Retry;
    using Polly.Timeout;
    using System.Net;
    using System.Net.Http;

    public static class RetryPolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
           TimeSpan.FromSeconds(2), // timeout duration
           TimeoutStrategy.Pessimistic); // throws TimeoutRejectedException

            var retryPolicy = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .Or<TimeoutRejectedException>()
                .OrResult(r => (int)r.StatusCode >= 500)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2));

            return Policy.WrapAsync(retryPolicy, timeoutPolicy);
        }
    }

}
