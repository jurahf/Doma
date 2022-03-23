using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Services.Authorization;
using Services.Converters;
using Services.EmailSending;
using Services.Parameters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Enums;

namespace Services
{
    public class UserService : BaseEntityService<UserViewModel, User>, IUserService
    {
        private readonly IJwtSigningEncodingKey signingEncodingKey;
        private readonly IUserRepository userRepository;
        private readonly IEmailSender emailSender;

        public UserService(
            IUserRepository userRepository,
            IEntityViewModelConverter<UserViewModel, User> converter,
            IJwtSigningEncodingKey signingEncodingKey,
            IEmailSender emailSender)
            : base(userRepository, converter)
        {
            this.userRepository = userRepository;
            this.signingEncodingKey = signingEncodingKey;
            this.emailSender = emailSender;
        }

        public UserViewModel GetByIdentityName(string identityName)
        {
            User user = userRepository.GetByIdentityName(identityName);
            return converter.ConvertToViewModel(user);
        }

        public LoginResult Login(string login, string password)
        {
            // Проверяем данные пользователя
            User user = userRepository.GetByIdentityName(login);

            if (user == null)
                return new LoginResult() { Success = false, ErrorCode = LoginError.WrongLoginOrPsw };

            bool verifyPassword = VerifyHash(user, user.PasswordHash, password);
            if (!verifyPassword)
                return new LoginResult() { Success = false, ErrorCode = LoginError.WrongLoginOrPsw };


            if (!user.IsConfirmed)
                return new LoginResult() { Success = false, ErrorCode = LoginError.UserIsNotConfirmed };

            if (user.IsBlocked)
                return new LoginResult() { Success = false, ErrorCode = LoginError.UserIsBlocked };

            // Создаем утверждения для токена.
            var claims = new Claim[]
            {
                new Claim(type:ClaimTypes.NameIdentifier, user.Email),
                new Claim(type:ClaimTypes.Email, user.Email),
                new Claim(type:ClaimTypes.Name, user.Name),
                new Claim(type:AuthorizationHelper.UserTypeClaimName, ((int)user.UserType).ToString()),
            };

            // Генерируем JWT.
            var token = new JwtSecurityToken(
                issuer: "DomaApp",
                audience: "DomaAppClient",
                claims: claims,
                expires: null, // DateTime.Now.AddMinutes(AuthorizationHelper.TokenExpiresTimeMinutes),
                signingCredentials: new SigningCredentials(
                        signingEncodingKey.GetKey(),
                        signingEncodingKey.SigningAlgorithm)
            ); ;

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new LoginResult() { Success = true, Token = jwtToken };
        }


        public async Task<RegisterResult> Register(RegistrationRequest request, string confirmUrl)
        {
            // проверяем
            if (request == null
                || string.IsNullOrEmpty(request.Name)
                || string.IsNullOrEmpty(request.Email)
                || string.IsNullOrEmpty(request.Password))
            {
                return new RegisterResult() { Success = false, ErrorCode = RegisterError.DataIsEmpty };
            }

            if (!emailSender.IsValid(request.Email))
                return new RegisterResult() { Success = false, ErrorCode = RegisterError.WrongEmailFormat };

            User existedUser = userRepository.GetByIdentityName(request.Email);
            if (existedUser != null)
                return new RegisterResult() { Success = false, ErrorCode = RegisterError.LoginAlreadyExists };

            int hardPoints = 0;
            if (request.Password.Any(x => Char.IsDigit(x)))
                hardPoints++;
            if (request.Password.Any(x => Char.IsUpper(x)))
                hardPoints++;
            if (request.Password.Any(x => Char.IsLower(x)))
                hardPoints++;
            if (request.Password.Any(x => Char.IsSymbol(x)))
                hardPoints++;

            if (hardPoints < 3)
                return new RegisterResult() { Success = false, ErrorCode = RegisterError.PasswordIsEasy };

            // создаем пользователя
            User user = new User()
            {
                UserType = (StoredModel.Enums.UserType)(int)request.UserType,
                Name = request.Name,
                Email = request.Email,
                IsConfirmed = false, 
                IsBlocked = false,
            };
            user.PasswordHash = GenerateHash(user, request.Password);
            user.ConfirmKey = Guid.NewGuid().ToString("N");

            userRepository.Add(user);

            // посылаем письмо для подтверждения почты
            string url = confirmUrl + $"?id={user.Id}&key={user.ConfirmKey}";
            await emailSender.SendEmailAsync(
                user.Email, 
                "Подтверждение регистрации", 
                $"Для завершения регистрации в Doma перейдите по <a href={HtmlEncoder.Default.Encode(url)}>ссылке.</a>");

            return new RegisterResult() { Success = true };
        }

        public bool ConfirmUser(int id, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            User user = userRepository.GetById(id);

            if (user == null)
                return false;

            if (user.ConfirmKey?.ToLower() == key?.ToLower())
            {
                user.IsConfirmed = true;
                userRepository.Update(user);

                return true;
            }
            else
            {
                return false;
            }
        }


        private string GenerateHash(User user, string psw)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            return hasher.HashPassword(user, psw);
        }

        private bool VerifyHash(User user, string pswHash, string psw)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            PasswordVerificationResult result = hasher.VerifyHashedPassword(user, pswHash, psw);
            return result != PasswordVerificationResult.Failed;
        }

    }
}