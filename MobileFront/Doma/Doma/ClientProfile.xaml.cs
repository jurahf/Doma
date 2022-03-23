using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientProfile : ContentPage
    {
        private readonly ICurrentUserProvider userProvider;
        private UserViewModel user;

        public ClientProfile(ICurrentUserProvider userProvider)
        {
            InitializeComponent();

            this.userProvider = userProvider;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            HideView();

            if (!userProvider.IsAuthenticated)
            {
                var loginOrRegisterPage = new LoginTabbedPage(userProvider);
                Navigation.PushAsync(loginOrRegisterPage);
                loginOrRegisterPage.Disappearing += (s, a) =>
                {
                    if (userProvider.IsAuthenticated)
                    {
                        user = userProvider.CurrentUser;
                        FillView();
                    }
                };
            }
            else
            {
                user = userProvider.CurrentUser;
                FillView();
            }
        }

        private void FillView()
        {
        }

        private void HideView()
        {
        }

    }
}