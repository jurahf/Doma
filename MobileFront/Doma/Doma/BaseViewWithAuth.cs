using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(300); // без этого нельзя применять навигацию в событии OnAppearing (будет OutOfRangeException)

            ShowNotAuthView();

            if (!await userProvider.IsAuthenticated())
            {
                var loginOrRegisterPage = new LoginTabbedPage(userProvider);
                await Navigation.PushAsync(loginOrRegisterPage);
                loginOrRegisterPage.Disappearing += async (s, a) =>
                {
                    if (await userProvider.IsAuthenticated())
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
