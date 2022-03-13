using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doma.RemoteServices.Common
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");

        Task<TResult> PostAsync<TResult>(string uri, object data, string token = "");

        Task PutAsync<TResult>(string uri, object data, string token = "");

        Task DeleteAsync(string uri, string token = "");
    }
}
