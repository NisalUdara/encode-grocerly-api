using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Ncode.Grocerly.RestApi.Authentication
{
    public class DummyAuthenticationOptions : AuthenticationSchemeOptions
    {
    }

    public class DummyAuthenticationHandler : AuthenticationHandler<DummyAuthenticationOptions>
    {

        public DummyAuthenticationHandler(
            IOptionsMonitor<DummyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "dummyuser"),
                };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new System.Security.Principal.GenericPrincipal(identity, null);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
