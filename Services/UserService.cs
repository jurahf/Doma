using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services
{
    public class UserService : BaseEntityService<UserViewModel, User>, IUserService
    {
        public UserService(
            IUserRepository repository,
            IEntityViewModelConverter<UserViewModel, User> converter)
            : base(repository, converter)
        {
        }
    }
}