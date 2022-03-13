using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.Common
{
    public abstract class BaseRemoteService<T> : IRemoteService<T> where T : IViewModel
    {
        private const string backendUri = "https://88fc-2a01-540-2487-dd00-8d49-7fac-932d-e24d.ngrok.io";
        protected readonly IRequestProvider requestProvider;
        
        protected abstract string ControllerPath { get; }


        public BaseRemoteService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }


        public virtual async Task<List<T>> GetPage(int page = 0, int limit = 100)
        {
            string uri = $"{backendUri}/{ControllerPath}?page={page}&limit={limit}";

            return await requestProvider.GetAsync<List<T>>(uri);
        }

        public virtual async Task<int> GetCount()
        {
            string uri = $"{backendUri}/{ControllerPath}/GetCount";

            return await requestProvider.GetAsync<int>(uri);
        }

        public virtual async Task<T> Get(int id)
        {
            string uri = $"{backendUri}/{ControllerPath}/{id}";

            return await requestProvider.GetAsync<T>(uri);
        }

        public virtual async Task<int> Add(T value)
        {
            string uri = $"{backendUri}/{ControllerPath}";

            return await requestProvider.PostAsync<int>(uri, value);
        }

        public virtual async Task Update(int id, T value)
        {
            string uri = $"{backendUri}/{ControllerPath}/{id}";

            await requestProvider.PutAsync<int>(uri, value);
        }

        public virtual async Task Delete(int id)
        {
            string uri = $"{backendUri}/{ControllerPath}/{id}";

            await requestProvider.DeleteAsync(uri);
        }

    }
}
