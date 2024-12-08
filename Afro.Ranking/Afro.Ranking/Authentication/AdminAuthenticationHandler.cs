using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Security.Claims;
using System.Text;

namespace Afro.Ranking.Authentication
{
    public class AdminAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
      //todo crete user service if needed
        public AdminAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

       

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() 
        {
            if (Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No Authencation Send");
            }
            try
            {
            var authHeader = Request.Headers["Authentication"].ToString();
            var authHeaderValue =authHeader.Substring("Basic".Length).Trim();
                var credentialsArray = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue)).Split(":");
                var username = credentialsArray[0];
                var password = credentialsArray[1];
                var userData = userService.GetUserData(username, password);
                if (userData != null) 
                {

                }
                else 
                {
                    return AuthenticateResult.Fail("");
                }
            }
            catch (Exception ex)
            {
             return AuthenticateResult.Fail("Invalide Authentication Header");
            }
        }
    }
}
