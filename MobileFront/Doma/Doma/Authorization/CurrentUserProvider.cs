using Doma.ControllerParameters;
using Doma.RemoteServices.ServiceDeclarations;
using Doma.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Enums;

namespace Doma.Authorization
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IAuthRemoteService authRemoteService;

        protected readonly string basePath;
        protected readonly string storageFileName;
        protected object lockObject = new object();
        private bool isInited = false;


        public CurrentUserProvider(IAuthRemoteService authRemoteService)
        {
            this.authRemoteService = authRemoteService;
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            storageFileName = $"Token.txt";

            Init();
        }

        public async Task<bool> IsAuthenticated()
        { 
            while (!isInited) 
            { 
                await Task.Delay(100); 
            }

            return CurrentUser != null; 
        }

        public UserViewModel CurrentUser { get; private set; }

        public string Token { get; private set; }


        public async Task<LoginError> TryLogin(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
            {
                return LoginError.DataIsEmpty;
            }

            try
            {
                LoginResult result = await authRemoteService.Login(new AuthenticationRequest()
                {
                    Email = login.Trim(), 
                    Password = password
                });

                if (result.Success)
                {
                    Token = result.Token;
                    CurrentUser = await authRemoteService.GetUserByIdentityName(login, Token);
                    SaveTokenFile(Token);
                }

                return result.ErrorCode;
            }
            catch (Exception ex)
            {
                Logout();
                return LoginError.UnexpectedError;
            }
        }

        public async Task<RegisterError> TryRegistration(string login, string password, string name, UserType type)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
            {
                return RegisterError.DataIsEmpty;
            }

            try
            {
                RegisterResult result = await authRemoteService.Register(new RegistrationRequest()
                {
                    Email = login.Trim(),
                    Password = password,
                    Name = name,
                    UserType = type
                });
                
                return result.ErrorCode;
            }
            catch (Exception ex)
            {
                return RegisterError.UnexpectedError;
            }
        }

        private void Logout()
        {
            Token = null;
            CurrentUser = null;
            RemoveTokenFile();
        }

        private void SaveTokenFile(string token)
        {
            try
            {
                lock (lockObject)
                {
                    string fileName = Path.Combine(basePath, storageFileName);
                    File.WriteAllText(fileName, token);
                }
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Can't to save data", ex);
            }
        }

        private void RemoveTokenFile()
        {
            try
            {
                lock (lockObject)
                {
                    string fileName = Path.Combine(basePath, storageFileName);

                    if (File.Exists(fileName))
                        File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string LoadTokenFromFile()
        {
            try
            {
                string fileName = Path.Combine(basePath, storageFileName);

                if (!File.Exists(fileName))
                    return null;

                string stringData;
                lock (lockObject)
                {
                    stringData = File.ReadAllText(fileName);
                }

                return stringData;
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Can't to load storage file", ex);
            }
        }

        private async void Init()
        {
            try
            {
                Token = LoadTokenFromFile();

                if (!string.IsNullOrEmpty(Token))
                {
                    var decodedToken = DecodeToken(Token);
                    DateTime.TryParseExact(
                        GetClaim(decodedToken, "ExpirationDate"), 
                        "yyyy-MM-dd-HH-mm-ss",
                        CultureInfo.InvariantCulture, 
                        DateTimeStyles.None,
                        out DateTime expirationDate);

                    if (DateTime.UtcNow <= expirationDate)
                    {
                        string login = GetClaim(decodedToken, ClaimTypes.NameIdentifier);
                        CurrentUser = await authRemoteService.GetUserByIdentityName(login, Token);
                    }
                    else
                    {
                        Logout(); // TODO: перелогиниться по логину и паролю
                    }
                }
            }
            catch
            {
                Logout();
            }

            isInited = true;
        }

        private JwtSecurityToken DecodeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);

            return jwtSecurityToken;
        }

        private string GetClaim(JwtSecurityToken decodedToken, string claimName)
        {
            if (string.IsNullOrEmpty(claimName))
                throw new ArgumentNullException(nameof(claimName));

            Claim claim = decodedToken.Claims.FirstOrDefault(c => c.Type?.ToLower() == claimName.ToLower());

            return claim?.Value;
        }


    }
}
