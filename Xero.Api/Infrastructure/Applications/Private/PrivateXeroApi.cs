using Xero.Api.Infrastructure.Authenticators;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Infrastructure.Applications.Private
{
    public class PrivateXeroApi : XeroApi
    {
        private static readonly XeroApiSettings ApplicationSettings = new XeroApiSettings();

        public PrivateXeroApi(bool includeRateLimiter = false, string userAgent = null) : 
            this(ApplicationSettings, includeRateLimiter, userAgent)
        {
        }

        public PrivateXeroApi(IXeroApiSettings settings, bool includeRateLimiter = false, string userAgent = null) :
            base(settings.BaseUrl, new PrivateAuthenticator(settings.SigningCertificatePath, settings.SigningCertificatePassword), new Consumer(settings.ConsumerKey, settings.ConsumerSecret), null, includeRateLimiter ? new RateLimiter.RateLimiter() : null, userAgent)
        {
        }
    }
}
