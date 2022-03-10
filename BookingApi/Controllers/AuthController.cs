using BookingApi.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login(
            AuthenticationRequest authRequest,
            [FromServices] IJwtSigningEncodingKey signingEncodingKey)
        {
            // 1. Проверяем данные пользователя из запроса.
            // TODO

            // 2. Создаем утверждения для токена.
            var claims = new Claim[]
            {
            new Claim(type:ClaimTypes.NameIdentifier, authRequest.Name)
            };

            // 3. Генерируем JWT.
            var token = new JwtSecurityToken(
                issuer: "DomaApp",
                audience: "DomaAppClient",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                        signingEncodingKey.GetKey(),
                        signingEncodingKey.SigningAlgorithm)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
