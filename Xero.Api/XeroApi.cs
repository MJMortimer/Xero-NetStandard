using Xero.Api.Core;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Payroll;

namespace Xero.Api
{
    public class XeroApi : IXeroApi
    {
        public XeroApi(IAuthenticator auth, IUser user = null, IRateLimiter rateLimiter = null, string userAgent = null)
            : this(auth, new XeroApiSettings(), user, rateLimiter, userAgent)
        {
        }

        public XeroApi(IAuthenticator auth, IXeroApiSettings applicationSettings, IUser user = null, IRateLimiter rateLimiter = null, string userAgent = null)
            : this(applicationSettings.BaseUrl, auth, new Consumer(applicationSettings.ConsumerKey, applicationSettings.ConsumerSecret), user, rateLimiter, userAgent)
        {
        }

        public XeroApi(string baseUrl, IAuthenticator auth, IConsumer consumer, IUser user = null, IRateLimiter rateLimiter = null, string userAgent = null)
        {
            Core = new XeroCoreApi(baseUrl, auth, consumer, user, rateLimiter)
            {
                UserAgent = userAgent
            };

            UsPayroll = new AmericanPayroll(baseUrl, auth, user, consumer, rateLimiter)
            {
                UserAgent = userAgent
            };

            AuPayroll = new AustralianPayroll(baseUrl, auth, user, consumer, rateLimiter)
            {
                UserAgent = userAgent
            };
        }
        
        public IXeroCoreApi Core { get; set; }
        public IAmericanPayroll UsPayroll { get; set; }
        public IAustralianPayroll AuPayroll { get; set; }
    }
}