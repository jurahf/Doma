using Services.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Services.ServiceDeclaration;
using ViewModel;
using System.Threading.Tasks;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login(AuthenticationRequest authRequest)
        {
            LoginResult loginResult = userService.Login(authRequest.Email, authRequest.Password);

            return Ok(loginResult);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegistrationRequest regRequest)
        {
            var confirmUrl = $"{Request.Scheme}://{Request.Host.Value}{Url.Action(nameof(Confirm))}";

            RegisterResult registerResult = await userService.Register(regRequest, confirmUrl);

            return Ok(registerResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Confirm")]
        public ActionResult<string> Confirm(int id, string key)
        {
            bool confirmed = userService.ConfirmUser(id, key);

            if (confirmed)
            {
                return Ok("Ваша учетная запись подтверждена");
            }
            else
            {
                return BadRequest("Что-то пошло не так, не удалось подтвердить учетную запись");
            }
        }

    }
}
