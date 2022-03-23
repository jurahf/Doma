using Doma.ControllerParameters;
using Doma.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.ServiceDeclarations
{
    public interface IAuthRemoteService
    {
        Task<LoginResult> Login(AuthenticationRequest authRequest);

        Task<RegisterResult> Register(RegistrationRequest regRequest);

        Task<UserViewModel> GetUserByIdentityName(string login, string token);
    }
}
