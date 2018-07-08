using Xero.Api.Infrastructure.Authenticators;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Infrastructure.Applications.Partner
{
    public class PartnerXeroApi : XeroApi
    {
        private static readonly XeroApiSettings ApplicationSettings = new XeroApiSettings();

        public PartnerXeroApi(PartnerAuthenticatorBase authenticator, IUser user, bool includeRateLimiter = false, string userAgent = null) :
            this(ApplicationSettings, authenticator, user, includeRateLimiter, userAgent)
        {
        }

        public PartnerXeroApi(IXeroApiSettings settings, PartnerAuthenticatorBase authenticator, IUser user, bool includeRateLimiter = false, string userAgent = null) :
            base(settings.BaseUrl, authenticator, new Consumer(settings.ConsumerKey, settings.ConsumerSecret), user, includeRateLimiter ? new RateLimiter.RateLimiter() : null, userAgent)
        {
        }
    }
}