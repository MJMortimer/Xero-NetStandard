using Xero.Api.Infrastructure.Authenticators;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Infrastructure.Applications.Public
{
    public class PublicXeroApi : XeroApi
    {
        private static readonly XeroApiSettings ApplicationSettings = new XeroApiSettings();

        public PublicXeroApi(PublicAuthenticatorBase authenticator, IUser user, bool includeRateLimiter = false, string userAgent = null) :
            this(ApplicationSettings, authenticator, user, includeRateLimiter, userAgent)
        {
        }

        public PublicXeroApi(IXeroApiSettings settings, PublicAuthenticatorBase authenticator, IUser user, bool includeRateLimiter = false, string userAgent = null) :
            base(settings.BaseUrl, authenticator,new Consumer(settings.ConsumerKey, settings.ConsumerSecret), user, includeRateLimiter ? new RateLimiter.RateLimiter() : null , userAgent)
        {
        }
    }
}