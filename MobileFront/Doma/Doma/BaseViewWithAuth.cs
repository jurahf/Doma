using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Doma
{
    public abstract class BaseViewWithAuth : ContentPage
    {
        protected readonly ICurrentUserProvider userProvider;

        public BaseViewWithAuth(ICurrentUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            ShowNotAuthView();

            if (!userProvider.IsAuthenticated)
            {
                var loginOrRegisterPage = new LoginTabbedPage(userProvider);
                Navigation.PushAsync(loginOrRegisterPage);
                loginOrRegisterPage.Disappearing += (s, a) =>
                {
                    if (userProvider.IsAuthenticated)
                    {
                        ShowFilledView();
                    }
                };
            }
            else
            {
                ShowFilledView();
            }
        }

        protected abstract void ShowFilledView();

        protected abstract void ShowNotAuthView();
    }
}
