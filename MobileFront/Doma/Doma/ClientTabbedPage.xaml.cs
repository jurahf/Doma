using Doma.Authorization;
using Doma.RemoteServices.ServiceDeclarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientTabbedPage : TabbedPage
    {
        public ClientTabbedPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();


            NavigationPage searchPages = new NavigationPage(
                new SearchPage(
                    serviceProvider.GetService<IRoomRemoteService>(),
                    serviceProvider.GetService<ICityRemoteService>(),
                    serviceProvider.GetService<IHotelRemoteService>()
                    ));
            searchPages.Title = "Поиск";
            searchPages.IconImageSource = "search.png";
            Children.Add(searchPages);


            Children.Add(new FaivoritesPage());
            Children.Add(new ClientBookingList());
            Children.Add(new Support());


            NavigationPage profilePages = new NavigationPage(
                new ClientProfile(serviceProvider.GetService<ICurrentUserProvider>()
                ));
            profilePages.Title = "Аккаунт";
            profilePages.IconImageSource = "account.png";
            Children.Add(profilePages);
        }
    }
}