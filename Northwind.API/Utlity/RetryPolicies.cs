namespace Northwind.API.Utlity
{
    using Polly;
    using Polly.Extensions.Http;
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

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 2,
                    durationOfBreak: TimeSpan.FromSeconds(10),
                    onBreak: (result, timespan) =>
                    {
                        Console.WriteLine("⚠️ Circuit broken!");
                    },
                    onReset: () => Console.WriteLine("✅ Circuit reset."),
                    onHalfOpen: () => Console.WriteLine("🕵️‍♂️ Testing circuit...")
        );
        }

        public static IAsyncPolicy<HttpResponseMessage> GetResilientPolicy()
        {
            var retry = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2));

            var breaker = Policy
                .Handle<HttpRequestException>()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));

            return Policy.WrapAsync(retry, breaker);
        }

    }
}
