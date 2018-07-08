using System;
using Xero.Api.Example.Console.Authenticators;
using Xero.Api.Infrastructure.Applications.Partner;
using Xero.Api.Infrastructure.Applications.Private;
using Xero.Api.Infrastructure.Applications.Public;
using Xero.Api.Infrastructure.OAuth;
using MemoryTokenStore = Xero.Api.Example.Console.TokenStores.MemoryTokenStore;

namespace Xero.Api.Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = Initialise();
            
            new Lister(api).List();
        }

        private static IXeroApi Initialise()
        {
            var settings = new XeroApiSettings();

            switch (settings.AppType.ToLower())
            {
                case "private":
                    return PrivateApp();
                case "public":
                    return PublicApp();
                case "partner":
                    return PartnerApp();
                default: throw new ApplicationException("AppType did not match one of: private, public, partner");
            }
        }

        private static IXeroApi PrivateApp()
        {
            return new PrivateXeroApi(true, "Xero API - Listing Example");
        }

        private static IXeroApi PublicApp()
        {
            var tokenStore = new MemoryTokenStore();
            var user = new ApiUser { Identifier = Environment.MachineName };
            var publicAuth = new PublicAuthenticator(tokenStore);

            return new PublicXeroApi(publicAuth, user, true, "Xero API - Listing example");
        }

        private static IXeroApi PartnerApp()
        {
            var tokenStore = new MemoryTokenStore();
            var user = new ApiUser { Identifier = Environment.MachineName };
            var partnerAuth = new PartnerAuthenticator(tokenStore);

            return new PartnerXeroApi(partnerAuth, user, true, "Xero API - Listing example");
        }
    }
}
