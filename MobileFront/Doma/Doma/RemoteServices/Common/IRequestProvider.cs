using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doma.RemoteServices.Common
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
    }
}
