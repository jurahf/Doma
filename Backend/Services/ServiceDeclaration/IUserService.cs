using Services.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services.ServiceDeclaration
{
    public interface IUserService : IEntityService<UserViewModel>
    {
        UserViewModel GetByIdentityName(string identityName);

        LoginResult Login(string username, string password);

        Task<RegisterResult> Register(RegistrationRequest request, string confirmUrl);

        bool ConfirmUser(int id, string confirmKey);

        //void BlockUser();
    }
}
