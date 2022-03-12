using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.Common
{
    public interface IRemoteService<T> where T : IViewModel
    {
        Task<List<T>> GetPageAsync(int page = 0, int limit = 100);
    }
}
