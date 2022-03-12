using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Doma.RemoteServices.Common
{
    public abstract class BaseRemoteService<T> : IRemoteService<T> where T : IViewModel
    {
        private const string backendUri = "http://eebd-2a01-540-2487-dd00-15c5-77ad-d8c0-cba1.ngrok.io";
        protected readonly IRequestProvider requestProvider;
        
        protected abstract string ControllerPath { get; }


        public BaseRemoteService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }


        public virtual async Task<List<T>> GetPageAsync(int page = 0, int limit = 100)
        {
            string uri = $"{backendUri}/{ControllerPath}?page={page}&limit={limit}";

            List<T> bookings = await requestProvider.GetAsync<List<T>>(uri);

            return bookings;
        }
    }
}
