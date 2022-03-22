using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.RepositoryDeclaration
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByIdentityName(string identityName);
    }
}
