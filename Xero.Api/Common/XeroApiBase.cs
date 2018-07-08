using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Common
{
    // It is used to plug together the the components which are used for authentication and serialization.
    public abstract class XeroApiBase
    {
        public string BaseUri { get; protected set; }

        public XeroHttpClient Client { get; private set; }

        protected XeroApiBase(string baseUrl, IAuthenticator auth, IConsumer consumer, IUser user, IRateLimiter rateLimiter)
        {
            BaseUri = baseUrl;

            Client = new XeroHttpClient(baseUrl, auth, consumer, user, rateLimiter);
        }

        public string UserAgent
        {
            get => Client.UserAgent;
            set => Client.UserAgent = value;
        }
    }
}