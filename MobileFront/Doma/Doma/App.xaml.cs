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

#if DEBUG
            services.AddSingleton<ICityRemoteService, CityFakeService>();
            services.AddSingleton<IRoomRemoteService, RoomFakeService>();
            services.AddSingleton<IHotelRemoteService, HotelFakeService>();
#else
            services.AddSingleton<IBookingRemoteService, BookingRemoteService>();
            services.AddSingleton<ICommodityRemoteService, CommodityRemoteService>();
            services.AddSingleton<ICityRemoteService, CityRemoteService>();
            services.AddSingleton<IRoomRemoteService, RoomRemoteService>();
            services.AddSingleton<IHotelRemoteService, HotelRemoteService>();
#endif

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
