using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Enums;

namespace Doma.Authorization
{
    public interface ICurrentUserProvider
    {
        Task<bool> IsAuthenticated();

        UserViewModel CurrentUser { get; }

        string Token { get; }

        Task<LoginError> TryLogin(string login, string password);

        Task<RegisterError> TryRegistration(string login, string password, string name, UserType type);
    }
}
