using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Services.Authorization
{
    public static class AuthorizationHelper
    {
        public const string UserTypeClaimName = "UserTypeCode";
        public const string UserId = "UserId";
        public const string HeaderName = "Authorization";
        public const string Bearer = "Bearer";
        public const string SecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
        public const int TokenExpiresTimeMinutes = 30;

        public static JwtSecurityToken GetToken(HttpRequest request)
        {
            string token = request.Headers[HeaderName];
            token = token?.Replace(Bearer, "")?.Trim();

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);

            return jwtSecurityToken;
        }


        public static string GetClaim(HttpRequest request, string claimName)
        {
            JwtSecurityToken token = GetToken(request);
            return GetClaim(token, claimName);
        }


        public static string GetClaim(JwtSecurityToken token, string claimName)
        {
            if (string.IsNullOrEmpty(claimName))
                throw new ArgumentNullException(nameof(claimName));

            Claim claim = token.Claims.FirstOrDefault(c => c.Type?.ToLower() == claimName.ToLower());

            return claim?.Value;
        }

    }
}
