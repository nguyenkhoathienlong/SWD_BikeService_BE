using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BikeService.Authentication
{
    public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.NoResult();
        }
    }
}
