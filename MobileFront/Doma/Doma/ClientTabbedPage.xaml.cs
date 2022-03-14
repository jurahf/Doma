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

            Children.Add(new SearchPage(
                serviceProvider.GetService<IBookingRemoteService>(), 
                serviceProvider.GetService<ICommodityRemoteService>(),
                serviceProvider.GetService<ICityRemoteService>()));

            Children.Add(new FaivoritesPage());
            Children.Add(new ClientBookingList());
            Children.Add(new Support());
            Children.Add(new ClientProfile());
        }
    }
}