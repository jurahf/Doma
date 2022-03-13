using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.Common
{
    public interface IRemoteService<T> where T : IViewModel
    {
        Task<int> GetCount();

        Task<List<T>> GetPage(int page = 0, int limit = 100);

        Task<T> Get(int id);

        Task<int> Add(T value);

        Task Update(int id, T value);

        Task Delete(int id);
    }
}
