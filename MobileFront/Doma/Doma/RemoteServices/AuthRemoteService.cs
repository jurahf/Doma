using Doma.ControllerParameters;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.ServiceDeclarations;
using Doma.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices
{
    public class AuthRemoteService : IAuthRemoteService
    {
        private readonly IRequestProvider requestProvider;
        protected const string backendUri = "https://doma-booking.ru";
        private string ControllerPath => "api/auth";


        public AuthRemoteService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }

        public async Task<LoginResult> Login(AuthenticationRequest authRequest)
        {
            return await requestProvider.PostAsync<LoginResult>($"{backendUri}/{ControllerPath}/Login", authRequest);
        }

        public async Task<RegisterResult> Register(RegistrationRequest regRequest)
        {
            return await requestProvider.PostAsync<RegisterResult>($"{backendUri}/{ControllerPath}/Register", regRequest);
        }

        public async Task<UserViewModel> GetUserByIdentityName(string login, string token)
        {
            return await requestProvider.GetAsync<UserViewModel>($"{backendUri}/api/user/GetByIdentityName?identityName=login", token);
        }
    }
}
