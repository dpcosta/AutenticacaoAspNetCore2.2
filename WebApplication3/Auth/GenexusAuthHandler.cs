using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebApplication3.Auth
{
    //https://ignas.me/tech/custom-authentication-asp-net-core-20/
    public class GenexusAuthHandler : AuthenticationHandler<GenexusAuthOptions>
    {
        public GenexusAuthHandler(IOptionsMonitor<GenexusAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //buscar usuário na sessão
            //buscar informações 
            return Task.FromResult(AuthenticateResult.Fail("Falha!"));
        }
    }
}
