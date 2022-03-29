using Doma.Authorization;
using Doma.RemoteServices;
using Doma.RemoteServices.Common;
using Doma.RemoteServices.FakeRemoteServices;
using Doma.RemoteServices.ServiceDeclarations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    public partial class App : Application
    {
        private static IServiceProvider serviceProvider { get; set; }

        public App(ServiceCollection services)
        {
            InitializeComponent();

            SetupServices(services);

            MainPage = new ClientTabbedPage(serviceProvider);
        }

        void SetupServices(ServiceCollection services)
        {
            services.AddSingleton<IRequestProvider, RequestProvider>();

            services.AddSingleton<IAuthRemoteService, AuthRemoteService>();
            services.AddSingleton<ICurrentUserProvider, CurrentUserProvider>();

            services.AddSingleton<IBookingRemoteService, BookingRemoteService>();
            services.AddSingleton<ICommodityRemoteService, CommodityRemoteService>();
            services.AddSingleton<ICityRemoteService, CityRemoteService>();
            services.AddSingleton<IRoomRemoteService, RoomRemoteService>();
            services.AddSingleton<IHotelRemoteService, HotelRemoteService>();
            services.AddSingleton<ILikeRemoteService, LikeRemoteService>();

            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
